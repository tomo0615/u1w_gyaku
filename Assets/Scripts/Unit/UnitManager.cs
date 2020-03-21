using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private List<BaseUnit> unitList = new List<BaseUnit>();

    //private List<GameObject> unitWaitList = new List<GameObject>();

    [SerializeField]
    private int unitValue = 10;
    /*
    [SerializeField]
    private Transform okeTransform = null;

    [SerializeField]
    private GameObject unitPrefab = null;
    */
    /*
    private IEnumerator Start()
    {
        for(int i = 0; i < unitValue; i++)
        {
            var unitObject = Instantiate(
                unitPrefab,
                okeTransform.position + Vector3.up * 5,
                Quaternion.identity) as GameObject;

            unitWaitList.Add(unitObject);

            yield return new WaitForSeconds(0.5f);
        }
        
    }*/

    public void AddUnitList(BaseUnit unit)
    {
        unitList.Add(unit);

        //Destroy(unitWaitList[0]);
        //unitWaitList.RemoveAt(0);
        unitValue--;
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
