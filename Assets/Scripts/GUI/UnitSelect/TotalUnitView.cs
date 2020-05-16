using UnityEngine;
using TMPro;

public class TotalUnitView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _totalCostText = default;

    public void OnTotalCostChanged(int costValue, int maxValue)
    {
        _totalCostText.text = costValue.ToString() + "/" + maxValue;
    }
}
