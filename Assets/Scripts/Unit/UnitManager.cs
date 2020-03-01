using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private List<BaseUnit> unitList = new List<BaseUnit>();

    public void AddUnitList(BaseUnit unit)
    {
        unitList.Add(unit);
    }

    public void SetTargetToAllUnit(Transform target)
    {
        foreach(BaseUnit unit in unitList)
        {
            unit.SetTarget(target);
        }
    }
}
