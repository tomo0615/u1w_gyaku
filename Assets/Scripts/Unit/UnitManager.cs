using System.Collections.Generic;
using UnityEngine;

public class UnitManager : SingletonMonoBehaviour<UnitManager>
{
    private List<BaseUnit> unitList = new List<BaseUnit>();

    [SerializeField]
    private int unitValue = 10;

    public void AddUnitList(BaseUnit unit)
    {
        unitList.Add(unit);

        unitValue--;
    }

    public void RemoveUnitList(BaseUnit unit)
    {
        unitList.Remove(unit);

        if(unitList.Count == 0 &&
           SummonableUnit() == false)
        {
            //TODO：GameOver演出
        }
    }

    public void SetTargetToAllUnit(Transform target)
    {
        foreach(BaseUnit unit in unitList)
        {
            unit.SetTarget(target);
        }
    }

    public bool SummonableUnit()
    {
        return unitValue > 0; 
    }
}
