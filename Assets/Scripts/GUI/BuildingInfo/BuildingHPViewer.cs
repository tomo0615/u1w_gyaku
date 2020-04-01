using UnityEngine;

public class BuildingHPViewer : MonoBehaviour
{
    [SerializeField]
    private HPBar _hpBar = default;

    public void ViewBuildingHP(int hitPoint)
    {
        //HPVarを表示
        _hpBar.OnHPValueChange(hitPoint);
    }
}
