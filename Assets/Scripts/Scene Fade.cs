using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Reflection;
using System;
using System.IO;

public class SceneFade : MonoBehaviour
{
    private Image _sceneFadeImage;
    [SerializeField]
    private Image _secondFadeImage;

    private void Awake()
    {
        _sceneFadeImage = GetComponent<Image>();
    }

    public IEnumerator FadeInCoroutine(float duration)
    {
        Color startColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 1);
        Color targetColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 0);

        yield return FadeCoroutine(startColor, targetColor, duration);

        gameObject.SetActive(false);
    }

    public IEnumerator FadeToSecondCoroutine(float duration)
    {
        Color startColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 1);
        Color targetColor = new Color(_secondFadeImage.color.r, _secondFadeImage.color.g, _secondFadeImage.color.b, 1);

        yield return FadeCoroutine(startColor, targetColor, duration);
    }

    public IEnumerator FadeOutCoroutine(float duration)
    {
        Color startColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 0);
        Color targetColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 1);

        gameObject.SetActive(true);
        yield return FadeCoroutine(startColor, targetColor, duration);
    }

    private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration)
    {
        float elapsedTime = 0;
        float elapsedPercentage = 0;

        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime / duration;
            _sceneFadeImage.color = Color.Lerp(startColor, targetColor, elapsedPercentage);

            yield return null;
            elapsedTime += Time.deltaTime;
        }
    }
}
