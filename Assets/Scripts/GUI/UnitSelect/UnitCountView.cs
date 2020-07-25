﻿using TMPro;
using UnityEngine;
using System;
using UniRx;
using UnityEngine.UI;

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

    public void Initialize()
    {
        // AddTo つけた方が良い
        _plusButton
            .OnClickAsObservable()
            .Subscribe(_ => _onPlus.OnNext(true));

        _minusButton
            .OnClickAsObservable()
            .Subscribe(_ => _onMinus.OnNext(false));
    }

    public void OnUnitCountChanged(int count)
    {
        _unitCountText.text = count.ToString();
    }
}
