using UnityEngine;
using System.Collections.Generic;

public class PlayerSummoner : MonoBehaviour
{
    [SerializeField]
    private UnitManager _unitManager = null;

    [SerializeField]
    private BaseUnit unit = null;

    [SerializeField]
    private float summonInterval = 0.1f;

    private float summonIntervalSave = 0f;

    private List<Vector3> summonList = new List<Vector3>();


    public void SummonSetting(Vector3 summonPosition)
    {
        summonIntervalSave += Time.deltaTime;

        if (summonIntervalSave >= summonInterval)
        {
            summonList.Add(summonPosition);

            summonIntervalSave = 0f;
        }
    }

    public void SummonUnit()
    {
        foreach(Vector3 summonPosition in summonList)
        {
            var instanceUnit = Instantiate(unit, summonPosition, Quaternion.identity);
            _unitManager.AddUnitList(instanceUnit);
        }

        summonList.Clear();
    }
}
