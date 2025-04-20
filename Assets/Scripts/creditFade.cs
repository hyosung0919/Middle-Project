using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class creditFade : MonoBehaviour
{
    public TextMeshProUGUI[] creditLines; // TextMeshPro 사용 시
    public float fadeDuration = 1f;
    public float showDuration = 2f;

    void Start()
    {
        StartCoroutine(PlayCredits());
    }

    IEnumerator PlayCredits()
    {
        foreach (TextMeshProUGUI line in creditLines)
        {
            yield return StartCoroutine(FadeText(line, 0f, 1f)); // Fade In
            yield return new WaitForSeconds(showDuration);       // Show
            yield return StartCoroutine(FadeText(line, 1f, 0f)); // Fade Out
        }

        // 끝나면 씬 전환 등 원하는 행동 가능
        SceneManager.LoadScene("Main");
    }

    IEnumerator FadeText(TextMeshProUGUI text, float startAlpha, float endAlpha)
    {
        float t = 0f;
        Color color = text.color;
        while (t < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t / fadeDuration);
            text.color = new Color(color.r, color.g, color.b, alpha);
            t += Time.deltaTime;
            yield return null;
        }
        text.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
