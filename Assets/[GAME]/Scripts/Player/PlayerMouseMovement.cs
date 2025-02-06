using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMouseMovement : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D _playerCollider;

    [SerializeField] private float speed = 5f; // Karakterin hareket hızı
    [SerializeField] private float angle = 45f; // Hareket açısı (derece)

    [SerializeField] private float _deathAnimWait = 0.5f;

    private bool canMove = true;
    private bool gameStarted = false;

    private Vector2 direction; // Hareket yönü

    private void OnEnable()
    {
        ActionManager.OnPlayerRevive += ResetMovementDirection;
        ActionManager.OnPlayerDeath += DeathAction;
        ActionManager.OnLevelFinish += DeathAction;
        ActionManager.GamePauseRequested += DisableMovement;
        ActionManager.GameResumeRequested += EnableMovement;
        ActionManager.OnGameStart += GameStartedAction;
    }

    private void OnDisable()
    {
        ActionManager.OnPlayerRevive -= ResetMovementDirection;
        ActionManager.OnPlayerDeath -= DeathAction;
        ActionManager.OnLevelFinish -= DeathAction;
        ActionManager.GamePauseRequested -= DisableMovement;
        ActionManager.GameResumeRequested -= EnableMovement;
        ActionManager.OnGameStart -= GameStartedAction;
    }

    private void Update()
    {
        if (canMove && gameStarted)
        {
            ApplyMovement();

            ChangeDirectionInput();
        }       
    }

    private void GameStartedAction()
    {
        gameStarted = true;
        ResetMovementDirection();
    }

    private void ApplyMovement()
    {
        transform.Translate(direction * speed * Time.deltaTime); // Hareketi uygula
    }

    private void ChangeDirection()
    {
        // Yönü tersine çevir (y eksenini değiştir)
        direction = new Vector2(direction.x, -direction.y);
        UpdateSpriteDirection();
    }

    private void ChangeDirectionInput()
    {
        // Fare tıklaması ile yön değiştir
        if (canMove == true && Input.GetMouseButtonDown(0) && !IsPointerOverUI())
        {
            ChangeDirection();
        }
    }

    private void ResetMovementDirection()
    {
        canMove = true;
        _playerCollider.enabled = true;
        direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
    }

    private void DeathAction()
    {
        StartCoroutine(DeathDragAction());
        _playerCollider.enabled = false;
    }

    private void DisableMovement()
    {
        canMove = false;
    }

    private void EnableMovement()
    {
        canMove = true;
    }

    private void UpdateSpriteDirection()
    {
        // Yukarı gidiyorsa ölçek pozitif, aşağı gidiyorsa ölçek negatif
        transform.localScale = new Vector3(1, direction.y < 0 ? -1 : 1, 1);
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }

    IEnumerator DeathDragAction()
    {
        yield return new WaitForSeconds(_deathAnimWait);
        DisableMovement();
    }

}