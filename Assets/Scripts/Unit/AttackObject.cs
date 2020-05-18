using UnityEngine;
using System.Collections;

public class AttackObject : MonoBehaviour
{
    private int attackPower;

    [SerializeField]
    private Transform originTransform = default;

    public virtual void ActiveAttackObject(int power)
    {
        attackPower = power;

        gameObject.SetActive(true);
    }

    public void SetOriginPosition()
    {
        transform.position = originTransform.position;
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
