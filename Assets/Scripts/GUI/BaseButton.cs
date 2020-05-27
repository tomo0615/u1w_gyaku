using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class BaseButton : MonoBehaviour
{
    private Button _button;

    public Button Button
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
        _button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                OnClicked();
            })
            .AddTo(gameObject);
    }

    public virtual void OnClicked()
    {
        PlayClickedSound();

        DoButtonClickedAnimation();
    }

    private void PlayClickedSound()
    {
        //Soundnagasu
    }

    private void DoButtonClickedAnimation()
    {
        _rectTransform.DOScale(Vector3.one * 1.1f, 0.1f)
            .OnComplete(() => _rectTransform.DOScale(Vector3.one, 0.1f));
    }
}
