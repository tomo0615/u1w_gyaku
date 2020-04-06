using UnityEngine;

public class AttackObject : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 1f;

    private int attackPower;

    public void Initialize(int power)
    {
        Destroy(gameObject, lifeTime);

        attackPower = power;
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.ApplyDamage(attackPower);
            
            GameEffectManager.Instance.OnGenelateEffect(
                transform.position,
                EffectType.Attack);
        }
    }
}
