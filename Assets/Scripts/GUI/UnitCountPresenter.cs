using UnityEngine;

public class UnitCountPresenter : MonoBehaviour
{
    [SerializeField]
    private UnitCountViewer _unitCountViewer = default;

    public void Initialize(int unitCount)
    {
        _unitCountViewer.InitializeUnitCountViewer();

        _unitCountViewer.ViewUnitCount(unitCount);
    }

    public void OnChangeUnitCount(int unitValue)
    {
        _unitCountViewer.ViewUnitCount(unitValue);
    }
}
