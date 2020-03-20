﻿using UnityEngine;

public class BaseBuilding : MonoBehaviour , IDamageable
{
    [SerializeField]
    private int hitPoint = 20;

    public void ApplyDamage()
    {
        hitPoint--;

        if(hitPoint <= 0)
        {
            //gameObject.SetActive(false);
            StageManager.Instance.RemoveAtBuilding(this);
            Destroy(gameObject);
        }
    }
}
