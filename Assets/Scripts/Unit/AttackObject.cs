using UnityEngine;
using System.Collections;

public class AttackObject : MonoBehaviour
{
    private int attackPower;

    public virtual void ActiveAttackObject(int power)
    {
        attackPower = power;

        gameObject.SetActive(true);
    }

    protected virtual void HitDamageableObject()
    {
        gameObject.SetActive(false);

        GameEffectManager.Instance.OnGenelateEffect(
            transform.position,
            EffectType.Attack);
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.ApplyDamage(attackPower);

            HitDamageableObject();
        }
    }
}
