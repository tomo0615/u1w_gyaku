using UnityEngine;
using System.Collections.Generic;

public class PlayerSummoner : MonoBehaviour
{
    [SerializeField]
    private UnitStorage _unitStorage = default;

    [SerializeField]
    private SummonEffect _summonEffect = default;

    [SerializeField]
    private float summonInterval = 0.1f;

    private float summonIntervalSave = 0f;

    private List<BaseUnit> summonList = new List<BaseUnit>();


    public void SummonSetting(Vector3 summonPosition, UnitType unitType)
    {
        if (_unitStorage.IsGetableUnit(unitType) == false) return;

        summonIntervalSave += Time.deltaTime;

        if (summonIntervalSave >= summonInterval)
        {
            BaseUnit unitPrefab = _unitStorage.GetUnitPrefab(unitType);

            //Unit召喚
            var instanceUnit = Instantiate(unitPrefab, summonPosition, Quaternion.identity);
            instanceUnit.gameObject.SetActive(false);

            UnitManager.Instance.AddSummonedUnitList(instanceUnit);
            summonList.Add(instanceUnit);


            _summonEffect.InstanceSummonEffect(summonPosition + Vector3.up);

            summonIntervalSave = 0f;
        }
    }

    public void SummonUnit()
    {
        foreach(BaseUnit unit in summonList)
        {
            unit.gameObject.SetActive(true);
        }

        summonList.Clear();
    }
}
