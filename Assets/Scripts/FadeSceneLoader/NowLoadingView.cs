using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class NowLoadingView : MonoBehaviour
{
    // const
    [SerializeField]
    private string loadingString = "Now Loading";

    private TextMeshProUGUI loadingText;

    private void Awake()
    {
        loadingText = GetComponent<TextMeshProUGUI>();
    }

    // 返り値不要なら void 型に
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

        // for にしたい -> (time / count) にできて可読性高
        while (count > 0)
        {
            loadingText.text += ".";

            count--;
            // キャッシュしたい
            yield return new WaitForSeconds(time / 3);
        }

        // チェック不要に思える
        if (action != null)
        {
            action();
            loadingText.text = "";
        }
    }
}