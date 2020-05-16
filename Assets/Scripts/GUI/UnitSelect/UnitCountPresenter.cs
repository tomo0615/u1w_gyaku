using UnityEngine;
using UniRx;

public class UnitCountPresenter : MonoBehaviour
{
    [SerializeField]
    private UnitType _unitType = UnitType.Normal;

    [SerializeField]
    private int unitCostValue = 0;

    [SerializeField]
    private UnitCountView _unitSelectView = default;

    [SerializeField]
    private TotalUnitView _totalUnitView = default;

    private UnitCountModel _unitCountModel;

    [SerializeField]
    private TotalUnitModel _totalUnitModel = default;

    [SerializeField]
    private UnitStorage _unitStorage = default;

    [SerializeField]
    private int maxTotalCost = 1000;

    private const int MAX_COUNT = 100;

    private const int MIN_COUNT = 0;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        _unitCountModel = new UnitCountModel();

        //個別のUnitCount監視
        _unitCountModel.UnitCounter
            .Subscribe(_unitSelectView.OnUnitCountChanged)
            .AddTo(gameObject);


        //TotalCost監視
        _totalUnitModel.TotalCost
            .Subscribe(value => _totalUnitView.OnTotalCostChanged(value,maxTotalCost))
            .AddTo(gameObject);

        SetEvents();
    }


    private void SetEvents()
    {
        _unitSelectView.OnPlusButtonClickedListener = OnPlusButtonClicked;

        _unitSelectView.OnMinusButtonClickedListener = OnMinusButtonClicked;
    }

    public void OnPlusButtonClicked()
    {
        int plusedCost = _totalUnitModel.TotalCost.Value + unitCostValue;

        if (maxTotalCost < plusedCost) return;

        if (_unitCountModel.UnitCounter.Value < MAX_COUNT &&
            _totalUnitModel.TotalCost.Value < maxTotalCost)
        {
            //Unitの数を変更
            _unitCountModel
                .SetUnitCount(_unitCountModel.UnitCounter.Value + 1);

            //TotalCost更新
            _totalUnitModel
                .SetTotalCost(_totalUnitModel.TotalCost.Value + unitCostValue);
        }
    }

    public void OnMinusButtonClicked()
    {
        if (_unitCountModel.UnitCounter.Value > MIN_COUNT)
        {
            //Unitの数を変更
            _unitCountModel
                .SetUnitCount(_unitCountModel.UnitCounter.Value - 1);

            //TotalCost更新
            _totalUnitModel
                .SetTotalCost(_totalUnitModel.TotalCost.Value - unitCostValue);
        }
    }

    public void OnReadyOKButtonClicked()
    {
        if (_totalUnitModel.TotalCost.Value > maxTotalCost) return;

        _unitStorage.SetHasUnitList(_unitType, _unitCountModel.UnitCounter.Value);
    }
}
