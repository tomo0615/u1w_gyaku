using UniRx;

public class UnitSelectModel
{
    private ReactiveProperty<int> _unitCount;

    public IReadOnlyReactiveProperty<int> UnitCounter
    {
        get { return _unitCount; }
    }

    public UnitSelectModel()
    {
        _unitCount = new ReactiveProperty<int>(0);
    }

    public void SetUnitCount(int count)
    {
        _unitCount.Value = count;
    }

}
