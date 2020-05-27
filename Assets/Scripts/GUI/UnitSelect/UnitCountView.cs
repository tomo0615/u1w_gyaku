using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class UnitCountView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _unitCountText = default;

    [SerializeField]
    private Button _plusButton = default;

    [SerializeField]
    private Button _minusButton = default;

    private readonly Subject<bool> _onPlus = new Subject<bool>();
    public IObservable<bool> OnPlus() => _onPlus;

    private readonly Subject<bool> _onMinus = new Subject<bool>();
    public IObservable<bool> OnMinus() => _onMinus;

    private RectTransform _rectTransform;

    private Tween _punchAnimation;

    private bool isPunching = false;
    public void Initialize()
    {
        _plusButton
            .OnClickAsObservable()
            .Subscribe(_ => _onPlus.OnNext(true));

        _minusButton
            .OnClickAsObservable()
            .Subscribe(_ => _onMinus.OnNext(false));

        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnUnitCountChanged(int count)
    {
        _unitCountText.text = count.ToString();

        if (isPunching) return;

        isPunching = true;

        _punchAnimation = _rectTransform.DOPunchScale(Vector3.one * 0.5f, 0.5f, 1)
            .OnComplete(() => isPunching = false);
    }
}
