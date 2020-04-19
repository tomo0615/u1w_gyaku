using UnityEngine;
using TMPro;

public class TotalUnitView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _totalCostText = default;

    public void OnTotalCostChanged(int costValue)
    {
        _totalCostText.text = costValue.ToString() + "/" + "1000"; //1000部分をmaxTotalCostに変更


        //超えていたら赤文字にするか何かを可視化する
    }
}
