using UnityEngine;
using TMPro;

public class TotalUnitView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _totalCostText = default;

    // 引数は costValue だけにしたい
    public void OnTotalCostChanged(int costValue, int maxValue)
    {
        _totalCostText.text = costValue.ToString() + "/" + maxValue;
    }
}
