using UnityEngine;
using DG.Tweening;

public class UnitSelectView : MonoBehaviour
{
    [SerializeField]
    private float animationTime = 0.5f;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void ActiveUnitSelectUI(bool isActive)
    {
        if(isActive)
        {
            _rectTransform.localScale = Vector3.zero;

            _rectTransform.DOScale(Vector3.one, animationTime);
        }
        else
        {
            _rectTransform.DOScale(Vector3.zero, animationTime);
        }
    } 
}
