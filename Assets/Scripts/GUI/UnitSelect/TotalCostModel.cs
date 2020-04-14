using UniRx;
using UnityEngine;

public class TotalCostModel : MonoBehaviour
{
    private ReactiveProperty<int> _totalCost = new ReactiveProperty<int>(0);

    public IReadOnlyReactiveProperty<int> TotalCost
    {
        get { return _totalCost; }
    }

    public void SetTotalCost(int costValue)
    {
        _totalCost.Value = costValue;
    }
}
