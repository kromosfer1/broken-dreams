using UnityEngine;
using DG.Tweening;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;    

    [Header("Death Animation")]
    [SerializeField] private float _fadeValue = 0f;
    [SerializeField] private float _fadeDuration = 1f;
    [SerializeField] private float _scaleValue = 0f;
    [SerializeField] private float _scaleDuration = 1f;


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
        _spriteRenderer.DOFade(_fadeValue, _fadeDuration);
        gameObject.transform.DOScale(_scaleValue, _scaleDuration);
    }

    private void HandlePlayerRevive()
    {
        _animator.SetBool("Dead", false);
        _spriteRenderer.DOFade(1f, 0.25f);
        gameObject.transform.DOScale(2f, 0.25f);
    }
}
