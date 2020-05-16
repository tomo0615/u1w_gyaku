using UniRx;
using UnityEngine;

public class TotalUnitModel : MonoBehaviour
{
    [SerializeField]
    private int _maxTotalCost = 100;

    public int MaxTotalCost => _maxTotalCost;

    private ReactiveProperty<int> _totalCost;

    public IReadOnlyReactiveProperty<int> TotalCost
    {
        get { return _totalCost; }
    }

    private void Awake()
    {
        _totalCost = new ReactiveProperty<int>(0);
    }

    public void SetTotalCost(int cost)
    {
        _totalCost.Value = cost;
    }
}
