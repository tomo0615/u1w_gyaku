using UnityEngine;
using UniRx;

public class TotalUnitPresenter : MonoBehaviour
{
    [SerializeField]
    private TotalUnitModel _totalUnitModel = default;

    [SerializeField]
    private TotalUnitView _totalUnitView = default;

    private void Start()
    {
        //View更新
        _totalUnitModel.TotalCost
             .Subscribe(value =>
             _totalUnitView.OnTotalCostChanged(value, _totalUnitModel.MaxTotalCost))
             .AddTo(gameObject);
    }
}
