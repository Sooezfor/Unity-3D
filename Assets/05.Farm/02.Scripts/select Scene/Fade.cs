using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image fadeImage;

    public static Action<float, Color, bool, Action> onFadeAction;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();   
    }
    private void OnEnable()
    {
        onFadeAction += OnFade;
    }
    private void OnDisable()
    {
        onFadeAction -= OnFade;    
    }

    void OnFade(float t, Color c, bool isFade, Action fadeEvent = null) //마지막 액션은 필요하면 넣고 아니면 넣지말아라 라는 디폴트값
    {
        StartCoroutine(FadeRoutine(t, c, isFade, fadeEvent));
    }
    IEnumerator FadeRoutine(float fadeTime, Color color, bool isFade, Action fadeEvent = null)
    {
        fadeImage.raycastTarget = true;
        float timer = 0f;
        float percent = 0f;
        while(percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;

            float value = isFade ? percent : 1 - percent;

            fadeImage.color = new Color(color.r, color.g, color.b, value);

            yield return null;                 
        }
        fadeEvent?.Invoke();
        fadeImage.raycastTarget = false;
    }
}
