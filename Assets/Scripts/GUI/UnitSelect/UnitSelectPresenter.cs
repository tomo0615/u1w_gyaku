using UnityEngine;
using UniRx;

public class UnitSelectPresenter : MonoBehaviour
{
    [SerializeField]
    private UnitSelectView _unitSelectView = default;

    private UnitSelectModel _unitSelectModel;

    private const int MAX_COUNT = 100;

    private const int MIN_COUNT = 0;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        _unitSelectModel = new UnitSelectModel();


        //Modelの値を監視　変化時Viewに反映
        _unitSelectModel.UnitCounter
            .Subscribe(_unitSelectView.OnUnitCountChanged)
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
        }
    }

    public void OnMinusButtonClicked()
    {
        if(_unitSelectModel.UnitCounter.Value > MIN_COUNT)
        {
            _unitSelectModel
                .SetUnitCount(_unitSelectModel.UnitCounter.Value - 1);
        }
    }
}
