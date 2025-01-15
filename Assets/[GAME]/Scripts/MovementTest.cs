using UnityEngine;

public class ZigZagMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Karakterin hareket hızı
    [SerializeField] private float angle = 45f; // Hareket açısı (derece)

    private Vector2 direction; // Hareket yönü

    void Start()
    {
        // Başlangıç yönü 45 derece yukarı
        direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
    }

    void Update()
    {
        // Hareketi uygula
        transform.Translate(direction * speed * Time.deltaTime);

        // Fare tıklaması ile yön değiştir
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        // Yönü tersine çevir (y eksenini değiştir)
        direction = new Vector2(direction.x, -direction.y);
    }
}
