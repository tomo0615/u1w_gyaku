using UniRx;

public class UnitCountModel
{
    private int _unitCost;

    // readonly にしたい
    private ReactiveProperty<int> _unitCount;

    public IReadOnlyReactiveProperty<int> UnitCounter
    {
        get { return _unitCount; }
    }

    // readonly にしたい
    private ReactiveProperty<int> _unitCostValue;

    public IReadOnlyReactiveProperty<int> UnitCostValue
    {
        get { return _unitCostValue; }
    }

    private const int MAX_COUNT = 100;
    private const int MIN_COUNT = 0;

    public UnitCountModel(int cost)
    {
        _unitCount = new ReactiveProperty<int>(0);

        _unitCostValue = new ReactiveProperty<int>(0);

        _unitCost = cost;
    }

    public void UpdateUnitCount(int count)
    {
        _unitCount.Value = count;
    }

    public bool IsUpdateUnitCount(int count)
    {
        return count <= MAX_COUNT &&
               count >= MIN_COUNT;
    }
}
