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
            StageManager.Instance.RemoveAtBuilding(this);

            GameEffectManager.Instance.OnGenelateEffect
                (transform.position,
                EffectType.BuildingExplosion);

            Destroy(gameObject);
        }
    }
}
