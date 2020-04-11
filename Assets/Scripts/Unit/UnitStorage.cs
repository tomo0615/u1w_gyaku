using System.Collections.Generic;
using UnityEngine;

public class UnitStorage : MonoBehaviour
{
    [SerializeField]
    private UnitTable unitTable = default;

    private Dictionary<UnitType, BaseUnit> unitDictionary;

    public void Awake()
    {
        unitDictionary = new Dictionary<UnitType, BaseUnit>
            {
                {UnitType.Normal, unitTable.normalUnit},
                {UnitType.Shield, unitTable.shieldUnit},
                {UnitType.Cannon, unitTable.cannonUnit}
            };
    }

    public BaseUnit GetUnitPrefab(UnitType unitType)
    {
        return unitDictionary[unitType];
    }
}
