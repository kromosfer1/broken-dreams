using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public UnityEvent OnCharDeath;

    private void OnEnable()
    {
        ActionManager.OnPlayerDeath += Death;
    }

    private void OnDisable()
    {
        ActionManager.OnPlayerDeath -= Death;
    }

    private void Death()
    {
        OnCharDeath?.Invoke();
    }
}
