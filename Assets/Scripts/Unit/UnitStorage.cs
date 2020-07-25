using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unit
{
    public class UnitStorage : MonoBehaviour
    {
        [SerializeField]
        private UnitTable unitTable = default;

        [SerializeField]
        private UnitStorageView _unitStorageView = null;

        private Dictionary<UnitType, BaseUnit> _unitDictionary;

        // 配列の方が好き
        private List<int> _hasUnitList; //UnitTypeの値とIndexが対応

        public bool IsFullHasUnitList { get; private set; } = false;

        public void Awake()
        {
            _unitDictionary = new Dictionary<UnitType, BaseUnit>
            {
                {UnitType.Normal, unitTable.normalUnit},
                {UnitType.Shield, unitTable.shieldUnit},
                {UnitType.Cannon, unitTable.cannonUnit}
            };

            _hasUnitList = new int[_unitDictionary.Count].ToList();
        }

        public void SetHasUnitList(UnitType type, int unitCount)
        {
            _hasUnitList[(int)type] = unitCount;
            _unitStorageView.ViewUnitCount(type, _hasUnitList[(int)type]);

            IsFullHasUnitList = true;
        }

        public BaseUnit GetUnitPrefab(UnitType type)
        {
            _hasUnitList[(int)type]--;

            _unitStorageView.ViewUnitCount(type, _hasUnitList[(int)type]);

            return _unitDictionary[type];
        }

        public bool IsGetableUnit(UnitType type)
        {
            return _hasUnitList[(int)type] > 0;
        }

        public bool IsGetableAllUnit()
        {
            // true || true || true の方が可読性高
            return
                !IsGetableUnit(UnitType.Normal) &&
                !IsGetableUnit(UnitType.Cannon) &&
                !IsGetableUnit(UnitType.Cannon);
        }
    }
}
