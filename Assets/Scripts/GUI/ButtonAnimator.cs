using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(RectTransform))]
public class ButtonAnimator : MonoBehaviour
{
    public enum ButtonAnimType
    {
        Punch,   
    }

    private RectTransform _rectTransform;
    [SerializeField] private ButtonAnimType clickedAnimType;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        var listenerButton = GetComponent<Button>()
            .OnClickAsObservable()
            .Subscribe(_ =>
            {
                Play();
            })
            .AddTo(gameObject);
    }

    private void Play()
    {
        switch (clickedAnimType)
        {
            case ButtonAnimType.Punch:
                //TODO: よしなにパラメータ化
                _rectTransform.DOScale(Vector3.one * 1.1f, 0.1f)
                    .OnComplete(() => _rectTransform.DOScale(Vector3.one, 0.1f));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }   
    }
}
