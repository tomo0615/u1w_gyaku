using UnityEngine;

public class BuildingHPPresenter : MonoBehaviour
{
    [SerializeField]
    private BuildingHPViewer _buildingHPViewer = default;

    public void OnChangeBuildingHP(int hitPoint)
    {
        _buildingHPViewer.ViewBuildingHP();
    }
}
