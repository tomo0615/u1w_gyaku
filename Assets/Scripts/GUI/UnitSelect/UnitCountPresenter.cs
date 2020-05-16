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

        _totalUnitModel.Initialize(_unitCountModel);

        //個別のUnitCount監視
        _unitCountModel.UnitCounter
            .Subscribe(_unitCountView.OnUnitCountChanged)
            .AddTo(gameObject);

        //加算
        _unitCountView.OnPlus()
            .Select(plusValue => _totalUnitModel.TotalCost.Value + unitCostValue)
            .Where(plusValue => _totalUnitModel.MaxTotalCost >= plusValue)
            .Subscribe(_ => _unitCountModel.UpdateUnitCount(_unitCountModel.UnitCounter.Value + 1))
            .AddTo(gameObject);

        //減算
        _unitCountView.OnMinus()
            .Select(minusValue => _totalUnitModel.TotalCost.Value - unitCostValue)
            .Where(minusValue => 0 <= minusValue)
            .Subscribe(_ => _unitCountModel.UpdateUnitCount(_unitCountModel.UnitCounter.Value - 1))
            .AddTo(gameObject);
    }

    public void OnReadyOKButtonClicked()
    {
        _unitStorage.SetHasUnitList(_unitType, _unitCountModel.UnitCounter.Value);
    }
}
