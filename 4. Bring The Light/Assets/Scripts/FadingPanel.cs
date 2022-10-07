using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;
    private Tween tween;
    public float fadeDur;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("BG");
        StartCoroutine(FadeEffect());
    }
    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        });
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
        });
    }

    private void Fade(float endVal, float duration, TweenCallback onEnd)
    {
        if (tween != null)
        {
            tween.Kill(false);
        }

        tween = canvas.DOFade(endVal, duration);
        tween.onComplete += onEnd;
    }

    private IEnumerator FadeEffect()
    {
        FadeOut(0f);
        yield return new WaitForSeconds(1f);
        FadeIn(fadeDur);
    }
}
