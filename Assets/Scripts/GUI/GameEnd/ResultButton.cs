using UnityEngine;
using DG.Tweening;
using Zenject;

public class ResultButton : MonoBehaviour
{
    [Inject]
    private FadeSceneLoader _fadeSceneLoader = default;

    private RectTransform _rectTransform;

    public void InitializeResultButton()
    {
        _rectTransform = GetComponent<RectTransform>();

        gameObject.SetActive(false);
    }

    public void SetActiveButton()
    {
        _rectTransform.localScale /= 10;

        gameObject.SetActive(true);

        _rectTransform.DOScale(_rectTransform.localScale * 10, 1f);

    }

    public void OnRetry()
    {
        _fadeSceneLoader.CurrentSceneLoad();
    }

    public void OnNextStage()
    {
        _fadeSceneLoader.NextSceneLoad();
    }
}
