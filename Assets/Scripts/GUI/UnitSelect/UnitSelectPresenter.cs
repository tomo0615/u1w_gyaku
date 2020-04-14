using UnityEngine;
using UniRx;

public class UnitSelectPresenter : MonoBehaviour
{
    [SerializeField]
    private int unitCostValue = 0;

    [SerializeField]
    private UnitSelectView _unitSelectView = default;

    [SerializeField]
    private TotalCostView _totalCostView = default;

    private UnitSelectModel _unitSelectModel;

    [SerializeField]
    private TotalCostModel _totalCostModel;

    private const int MAX_COUNT = 100;

    private const int MIN_COUNT = 0;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        _unitSelectModel = new UnitSelectModel();

        //個別のUnitCount監視
        _unitSelectModel.UnitCounter
            .Subscribe(_unitSelectView.OnUnitCountChanged)
            .AddTo(gameObject);


        //TotalCost監視
        _totalCostModel.TotalCost
            .Subscribe(_totalCostView.OnTotalCostChanged)
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

            _totalCostModel
                .SetTotalCost(_totalCostModel.TotalCost.Value + unitCostValue);
        }
    }

    public void OnMinusButtonClicked()
    {
        if(_unitSelectModel.UnitCounter.Value > MIN_COUNT)
        {
            _unitSelectModel
                .SetUnitCount(_unitSelectModel.UnitCounter.Value - 1);


            _totalCostModel
                .SetTotalCost(_totalCostModel.TotalCost.Value - unitCostValue);
        }
    }
}
