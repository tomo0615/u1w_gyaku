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

    private UnitCountModel _unitSelectModel;

    [SerializeField]
    private TotalUnitModel _totalUnitModel = default;

    [SerializeField]
    private UnitStorage _unitStorage = default;

    private const int MAX_COUNT = 100;

    private const int MIN_COUNT = 0;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        _unitSelectModel = new UnitCountModel();

        //個別のUnitCount監視
        _unitSelectModel.UnitCounter
            .Subscribe(_unitSelectView.OnUnitCountChanged)
            .AddTo(gameObject);


        //TotalCost監視
        _totalUnitModel.TotalCost
            .Subscribe(_totalUnitView.OnTotalCostChanged)
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
        if (_unitSelectModel.UnitCounter.Value < MAX_COUNT)
        {
            _unitSelectModel
                .SetUnitCount(_unitSelectModel.UnitCounter.Value + 1);

            _totalUnitModel
                .SetTotalCost(_totalUnitModel.TotalCost.Value + unitCostValue);
        }
    }

    public void OnMinusButtonClicked()
    {
        if (_unitSelectModel.UnitCounter.Value > MIN_COUNT)
        {
            //Unitの数を変更
            _unitSelectModel
                .SetUnitCount(_unitSelectModel.UnitCounter.Value - 1);


            //TotalCost更新
            _totalUnitModel
                .SetTotalCost(_totalUnitModel.TotalCost.Value - unitCostValue);
        }
    }

    public void OnReadyOKBUttonClicked()
    {
        _unitStorage.SetHasUnitList(_unitType, _unitSelectModel.UnitCounter.Value);
    }
}
