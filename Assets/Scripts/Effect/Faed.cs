using UnityEngine;

public class Faed : MonoBehaviour
{
    public CanvasGroup canvasGroup;   
    public float fadeDuration = 2f;   

    void Start()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            StartCoroutine(FadeIn());
        }
    }

    System.Collections.IEnumerator FadeIn()
    {
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}
