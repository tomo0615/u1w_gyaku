using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitStorage : MonoBehaviour
{
    [SerializeField]
    private UnitTable unitTable = default;

    [SerializeField]
    private UnitStorageView _unitStorageView = null;

    private Dictionary<UnitType, BaseUnit> unitDictionary;

    private List<int> hasUnitList; //UnitTypeの値とIndexが対応

    public bool IsFullHasUnitList { get; private set; } = false;

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
        _unitStorageView.ViewUnitCount(type, hasUnitList[(int)type]);

        IsFullHasUnitList = true;
    }

    public BaseUnit GetUnitPrefab(UnitType type)
    {
        hasUnitList[(int)type]--;

        _unitStorageView.ViewUnitCount(type, hasUnitList[(int)type]);

        return unitDictionary[type];
    }

    public bool IsGetableUnit(UnitType type)
    {
        return hasUnitList[(int)type] > 0;
    }

    public bool IsGetableAllUnit()
    {
        return
            !IsGetableUnit(UnitType.Normal) &&
            !IsGetableUnit(UnitType.Cannon) &&
            !IsGetableUnit(UnitType.Cannon);
    }
}
