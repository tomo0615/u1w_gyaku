using UnityEngine;

public class UnitCountPresenter : MonoBehaviour
{
    [SerializeField]
    private UnitCountViewer _unitCountViewer = default;

    private void Awake()
    {
        _unitCountViewer.InitializeUnitCountViewer();
    }

    public void OnChangeUnitCount(int unitValue)
    {
        _unitCountViewer.ViewUnitCount(unitValue);
    }
}
