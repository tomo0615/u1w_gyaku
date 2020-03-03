using System.Collections.Generic;
using UnityEngine;

public class AttackRangeArea : MonoBehaviour
{
    private List<GameObject> unitList = new List<GameObject>();


    public Vector3 GetCurrentTarget()
    {
        foreach(var unit in unitList)
        {
            if (unit.activeSelf)
            {
               return unit.transform.position;
            }
        }

        return Vector3.zero;
    }

    public bool IsAreaEmpty()
    {
        return unitList.Count == 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        var attackable = other.GetComponent<IAttackable>();

        if(attackable != null)
        {
            unitList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {       
        unitList.Remove(other.gameObject);
    }
}
