using UnityEngine;
using Unity.Cinemachine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource _impulseSource; // Cinemachine impulse kaynağı
    [SerializeField] private float _shakeForce = 1f; // Titreşim şiddeti

    private void OnEnable()
    {
        ActionManager.OnPlayerDeath += TriggerShake;
    }

    private void OnDisable()
    {
        ActionManager.OnPlayerDeath -= TriggerShake;
    }

    public void TriggerShake()
    {
        // Impulse oluştur
        _impulseSource.GenerateImpulseWithForce(_shakeForce);
    }
}
