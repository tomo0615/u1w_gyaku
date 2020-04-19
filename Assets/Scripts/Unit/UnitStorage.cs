using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitStorage : MonoBehaviour
{
    [SerializeField]
    private UnitTable unitTable = default;

    private Dictionary<UnitType, BaseUnit> unitDictionary;

    private List<int> hasUnitList; //UnitTypeの値とIndexが対応

    public void Awake()
    {
        unitDictionary = new Dictionary<UnitType, BaseUnit>
            {
                {UnitType.Normal, unitTable.normalUnit},
                {UnitType.Shield, unitTable.shieldUnit},
                {UnitType.Cannon, unitTable.cannonUnit}
            };

        hasUnitList = new int[unitDictionary.Count].ToList();
    }

    public void SetHasUnitList(UnitType type, int unitCount)
    {
        hasUnitList[(int)type] = unitCount;
    }

    public BaseUnit GetUnitPrefab(UnitType type)
    {
        return unitDictionary[type];
    }
}
