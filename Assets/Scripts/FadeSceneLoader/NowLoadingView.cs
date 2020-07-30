using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class NowLoadingView : MonoBehaviour
{
    [SerializeField]
    private string loadingString = "Now Loading";

    private TextMeshProUGUI _loadingText;

    [SerializeField] private float fadeCount = 1;
        
    private void Awake()
    {
        _loadingText = GetComponent<TextMeshProUGUI>();
    }

    public Coroutine DOAnimation(float time, Action action)
    {
        StopAllCoroutines();
        return StartCoroutine(AnimationCoroutine(time, action));
    }

    //デザイン決定後変更
    private IEnumerator AnimationCoroutine(float time, Action action)
    {
        var count = 3;

        _loadingText.text = loadingString;

        while (count > 0)
        {
            _loadingText.text += "."; //nowloading...の点を作成

            count--;
            yield return new WaitForSeconds(time / 3);
        }

        if (action == null) yield break;
        
        action();
        _loadingText.text = "";
    }
}