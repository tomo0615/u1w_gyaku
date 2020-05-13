using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class NowLoadingView : MonoBehaviour
{
    [SerializeField]
    private string loadingString = "Now Loading";

    private TextMeshProUGUI loadingText;

    private void Awake()
    {
        loadingText = GetComponent<TextMeshProUGUI>();
    }

    public Coroutine DOAnimation(float time, Action action)
    {
        StopAllCoroutines();
        return StartCoroutine(AnimationCoroutine(time, action));
    }

    //デザイン決定後変更
    private IEnumerator AnimationCoroutine(float time, Action action)
    {
        int count = 3;

        loadingText.text = loadingString;

        while (count > 0)
        {
            loadingText.text += ".";

            count--;
            yield return new WaitForSeconds(time / 3);
        }

        if (action != null)
        {
            action();
            loadingText.text = "";
        }
    }
}