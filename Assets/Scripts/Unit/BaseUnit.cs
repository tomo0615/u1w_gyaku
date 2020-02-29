using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseUnit : MonoBehaviour , IAttackable
{
    [SerializeField]
    private int hitPoint = 1;

    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    protected Transform attackTarget;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void MoveTartget()
    {
        transform.LookAt(attackTarget.position);
        _rigidbody.velocity = transform.forward * moveSpeed;
    }

    public void Attacked()
    {
        hitPoint--;

        if (hitPoint <= 0)
        { 
            // TODO:撃破時Effect

            gameObject.SetActive(false);
            return;
        }
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
