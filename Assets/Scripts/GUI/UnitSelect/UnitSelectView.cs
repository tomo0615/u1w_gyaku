using UnityEngine;
using DG.Tweening;

public class UnitSelectView : MonoBehaviour
{
    [SerializeField]
    private float animationTime = 0.5f;

    [SerializeField]
    private float scaleValue = 1f;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void ActiveUnitSelectUI(bool isActive)
    {
        if (isActive)
        {
            gameObject.SetActive(true);

            _rectTransform.localScale = Vector3.zero;

            var overValue = scaleValue * 1.1f;
            // 使用していないなら削除
            var overScale = new Vector3(overValue, overValue);

            // Sequence 使えば綺麗になりそう
            _rectTransform.DOScale(overValue, animationTime)
                .OnComplete(() =>
                {
                    _rectTransform.DOScale(new Vector3(scaleValue, scaleValue), animationTime);
                });
        }
        else
        {
            _rectTransform.DOScale(Vector3.zero, animationTime)
                .OnComplete(() => gameObject.SetActive(false));
        }
    } 
}
