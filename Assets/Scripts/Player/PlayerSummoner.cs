using UnityEngine;
using System.Collections.Generic;

public class PlayerSummoner : MonoBehaviour
{
    [SerializeField]
    private UnitManager _unitManager = null;

    [SerializeField]
    private GameObject FuroOkePrefab = null;

    [SerializeField]
    private BaseUnit unit = null;

    [SerializeField]
    private float summonInterval = 0.1f;

    private float summonIntervalSave = 0f;

    private List<Vector3> summonList = new List<Vector3>();

    private List<GameObject> furoOkeList = new List<GameObject>();


    public void SummonSetting(Vector3 summonPosition)
    {
        summonIntervalSave += Time.deltaTime;

        if (summonIntervalSave >= summonInterval)
        {
            summonList.Add(summonPosition);

            var furoOke 
                = Instantiate(FuroOkePrefab,
                summonPosition + Vector3.up,
                Quaternion.identity) as GameObject;

            furoOkeList.Add(furoOke);

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

        foreach(GameObject furoOke in furoOkeList)
        {
            Destroy(furoOke);
        }

        furoOkeList.Clear();
        summonList.Clear();
    }
}
