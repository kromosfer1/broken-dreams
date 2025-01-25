using UnityEngine;
using System;

public class PlayerMouseMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Karakterin hareket hızı
    [SerializeField] private float angle = 45f; // Hareket açısı (derece)

    private Vector2 direction; // Hareket yönü

    private void OnEnable()
    {
        ActionManager.OnPlayerRevive += ResetMovementDirection;
    }

    private void OnDisable()
    {
        ActionManager.OnPlayerRevive -= ResetMovementDirection;
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
        // Hareketi uygula
        transform.Translate(direction * speed * Time.deltaTime);
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
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    private void ResetMovementDirection()
    {
        direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
    }

    void UpdateSpriteDirection()
    {
        // Yukarı gidiyorsa ölçek pozitif, aşağı gidiyorsa ölçek negatif
        transform.localScale = new Vector3(1, direction.y < 0 ? -1 : 1, 1);
    }
}