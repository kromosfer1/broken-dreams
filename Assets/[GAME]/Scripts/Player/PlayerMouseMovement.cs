using UnityEngine;
using System;
using System.Collections;

public class PlayerMouseMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Karakterin hareket hızı
    [SerializeField] private float angle = 45f; // Hareket açısı (derece)

    [SerializeField] private float _deathAnimWait = 0.5f;

    private bool _canMove = true;

    private Vector2 direction; // Hareket yönü

    private void OnEnable()
    {
        ActionManager.OnPlayerRevive += ResetMovementDirection;
        ActionManager.OnPlayerDeath += DisableMovement;
    }

    private void OnDisable()
    {
        ActionManager.OnPlayerRevive -= ResetMovementDirection;
        ActionManager.OnPlayerDeath -= DisableMovement;
    }

    private void Start()
    {
        // Başlangıç yönü 45 derece yukarı
        ResetMovementDirection();
    }

    private void Update()
    {
        ApplyMovement();

        ChangeDirectionInput();
    }

    private void ApplyMovement()
    {
        if (_canMove)
        {
            transform.Translate(direction * speed * Time.deltaTime); // Hareketi uygula
        }
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
        if (Input.GetMouseButtonDown(0) && _canMove==true)
        {
            ChangeDirection();
        }
    }

    private void ResetMovementDirection()
    {
        _canMove = true;
        direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
    }

    private void DisableMovement()
    {
        StartCoroutine(DeathDragAction());
    }

    private void UpdateSpriteDirection()
    {
        // Yukarı gidiyorsa ölçek pozitif, aşağı gidiyorsa ölçek negatif
        transform.localScale = new Vector3(1, direction.y < 0 ? -1 : 1, 1);
    }

    IEnumerator DeathDragAction()
    {
        yield return new WaitForSeconds(_deathAnimWait);
        _canMove = false;
    }

}