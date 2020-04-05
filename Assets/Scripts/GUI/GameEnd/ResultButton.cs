using UnityEngine;
using DG.Tweening;

public class ResultButton : MonoBehaviour
{
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
        //Scene遷移
    }

    public void OnNextStage()
    {
        //Scene遷移
    }
}
