using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public UnityEvent OnCharDeath;
    public UnityEvent OnWin;

    private void OnEnable()
    {
        ActionManager.OnPlayerDeath += Death;
        ActionManager.OnLevelFinish += Win;
    }

    private void OnDisable()
    {
        ActionManager.OnPlayerDeath -= Death;
        ActionManager.OnLevelFinish -= Win;
    }

    private void Death()
    {
        OnCharDeath?.Invoke();
    }

    private void Win()
    {
        OnWin?.Invoke();
    }
}
