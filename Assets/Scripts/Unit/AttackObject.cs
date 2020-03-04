using UnityEngine;

public class AttackObject : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 1f;

    private void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.ApplyDamage();
        }
    }
}
