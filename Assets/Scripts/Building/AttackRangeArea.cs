using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeArea : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();


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
