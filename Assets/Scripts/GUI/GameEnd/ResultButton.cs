using UnityEngine;
using DG.Tweening;
using Zenject;
using UniRx;
using System;

public class ResultButton : MonoBehaviour
{
    [Inject]
    private readonly FadeSceneLoader _fadeSceneLoader = default;

    private RectTransform _rectTransform;

    public Action OnClickedResultButtonListner = default;

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
        OnClickedResultButtonListner.Invoke();

        _fadeSceneLoader.CurrentSceneLoad();
    }

    public void OnNextStage()
    {
        OnClickedResultButtonListner.Invoke();

        _fadeSceneLoader.NextSceneLoad();
    }

    public void OnReturnStageSelect()
    {
        OnClickedResultButtonListner.Invoke();

        _fadeSceneLoader.JumpSceneLoad(SceneName.StageSelect);
    }
}
