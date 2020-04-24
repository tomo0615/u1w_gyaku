using TMPro;
using UnityEngine;
using System;

public class UnitCountView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _unitCountText = default;

    public Action OnPlusButtonClickedListener;

    public Action OnMinusButtonClickedListener;

    public void OnUnitCountChanged(int count)
    {
        _unitCountText.text = count.ToString();
    }

    public void OnPlusButtonClicked()
    {
        OnPlusButtonClickedListener?.Invoke();
    }

    public void OnMinusButtonClicked()
    {
        OnMinusButtonClickedListener?.Invoke();
    }
}
