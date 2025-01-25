using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        ActionManager.OnPlayerDeath += HandlePlayerDeath;
        ActionManager.OnPlayerRevive += HandlePlayerRevive;
    }

    private void OnDisable()
    {
        ActionManager.OnPlayerDeath -= HandlePlayerDeath;
        ActionManager.OnPlayerRevive -= HandlePlayerRevive;
    }

    private void HandlePlayerDeath()
    {
        _animator.SetBool("Dead", true);
    }

    private void HandlePlayerRevive()
    {
        _animator.SetBool("Dead", false);
    }
}
