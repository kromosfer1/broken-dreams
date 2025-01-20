using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private Vector2 _respawnPoint;

    private void OnEnable()
    {
        ActionManager.OnPlayerDeath += DeathAction;
        ActionManager.OnReviveRequested += Revive;
    }

    private void OnDisable()
    {
        ActionManager.OnPlayerDeath -= DeathAction;
        ActionManager.OnReviveRequested -= Revive;
    }

    private void Start()
    {
        _respawnPoint = gameObject.transform.position;
        Revive();
    }

    private void DeathAction()
    {
        Debug.Log("Died!");
    }

    private void Revive()
    {
        gameObject.transform.position = _respawnPoint;
        ActionManager.OnPlayerRevive?.Invoke();
    }
}
