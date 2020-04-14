using UniRx;
using UnityEngine;

public class TotalCostPresenter : MonoBehaviour
{
    private TotalCostModel _totalCostModel;

    [SerializeField]
    private TotalCostView _totalCostView = default;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _totalCostModel = new TotalCostModel();

        //TotalCost監視
        _totalCostModel.TotalCost
            .Subscribe(_totalCostView.OnTotalCostChanged)
            .AddTo(gameObject);
    }

    public void OnButtonCliced()
    {

    }
}
