using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UnitCountPresenter : MonoBehaviour
{
    [SerializeField]
    private UnitType _unitType = UnitType.Normal;

    [SerializeField]
    private int unitCostValue = 0;

    [SerializeField]
    private UnitCountView _unitCountView = default;

    private UnitCountModel _unitCountModel;

    [SerializeField]
    private TotalUnitModel _totalUnitModel = default;

    [SerializeField]
    private UnitStorage _unitStorage = default;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _unitCountModel = new UnitCountModel(unitCostValue);
        _unitCountView.Initialize();


        //個別のUnitCount監視
        _unitCountModel.UnitCounter
            .Subscribe(_unitCountView.OnUnitCountChanged)
            .AddTo(gameObject);

        //加算
        _unitCountView.OnPlus()
            .Select(plusValue => _totalUnitModel.TotalCost.Value + unitCostValue)
            .Where(plusValue => _totalUnitModel.MaxTotalCost >= plusValue &&
                   _unitCountModel.IsUpdateUnitCount(_unitCountModel.UnitCounter.Value + 1))
            .Subscribe(_ =>
            {
                _unitCountModel.UpdateUnitCount(_unitCountModel.UnitCounter.Value + 1);

                _totalUnitModel.SetTotalCost(unitCostValue);
            })
            .AddTo(gameObject);

        //減算
        _unitCountView.OnMinus()
            .Select(count => _unitCountModel.UnitCounter.Value - 1)
            .Where(count => _unitCountModel.IsUpdateUnitCount(count))
            .Subscribe(count =>
            {
                _unitCountModel.UpdateUnitCount(count);

                _totalUnitModel.SetTotalCost(unitCostValue * -1);
            })
            .AddTo(gameObject);
    }

    public void OnReadyOKButtonClicked()
    {
        _unitStorage.SetHasUnitList(_unitType, _unitCountModel.UnitCounter.Value);
    }
}
