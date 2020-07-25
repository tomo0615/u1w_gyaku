using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

public class BaseButton : MonoBehaviour
{
    private Button _button;

    protected Button Button
    {
        get
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            return _button;
        }
    }

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        Button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                OnClicked();
            })
            .AddTo(gameObject);
    }

    public virtual void OnClicked()
    {
        DoPunchAnimation();
    }

    private void DoPunchAnimation()
    {
        _rectTransform.DOScale(Vector3.one * 1.1f, 0.1f)
            .OnComplete(() => _rectTransform.DOScale(Vector3.one, 0.1f));
    }
}
