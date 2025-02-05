using UnityEngine;
using DG.Tweening;
using AnilHarmandali.UnityRuntimeUI;
using System;

public class PanelFadeAnimation : PanelAnimationBase
{
    private CanvasGroup canvasGroup;
    private float startAlpha = 0;
    private float endAlpha = 1;

    private void Start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    public override void PlayShowAnimation(Action onComplete = null)
    {
        canvasGroup.DOFade(endAlpha, Duration).SetEase(ShowEase)
            .OnComplete(() => onComplete?.Invoke());
    }

    public override void PlayHideAnimation(Action onComplete = null)
    {
        canvasGroup.DOFade(startAlpha, Duration).SetEase(HideEase)
            .OnComplete(() => onComplete?.Invoke());
    }

}
