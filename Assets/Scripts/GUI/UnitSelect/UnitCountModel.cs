using UniRx;

public class UnitCountModel
{
    private ReactiveProperty<int> _unitCount;

    public IReadOnlyReactiveProperty<int> UnitCounter
    {
        get { return _unitCount; }
    }

    public UnitCountModel()
    {
        _unitCount = new ReactiveProperty<int>(0);
    }

    public void SetUnitCount(int count)
    {
        _unitCount.Value = count;
    }
}
