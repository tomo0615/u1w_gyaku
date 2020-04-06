﻿using UnityEngine;

public class BaseBuilding : MonoBehaviour , IDamageable
{
    [SerializeField]
    private int hitPoint = 20;

    [SerializeField]
    private HPBar hpBar = default;

    private void Start()
    {
        hpBar.SetMaxHPValue(hitPoint);
    }

    public void ApplyDamage(int damageValue)
    {
        hitPoint -= damageValue;

        hpBar.OnHPValueChange(hitPoint);

        if (hitPoint <= 0)
        {
            StageManager.Instance.RemoveAtBuilding(this);

            GameEffectManager.Instance.OnGenelateEffect
                (transform.position,
                EffectType.BuildingExplosion);

            Destroy(gameObject);
        }
    }
}
