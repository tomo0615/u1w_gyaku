using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitBullet : AttackObject
{
    [SerializeField]
    private float moveSpeed = 20f;

    private Rigidbody _rigidbody;

    [SerializeField]
    private Transform shooterTransform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void ActiveAttackObject(int power)
    {
        base.ActiveAttackObject(power);

        SetVelocity();
    }

    protected override void HitDamageableObject()
    {
        base.HitDamageableObject();

        transform.position = shooterTransform.position;
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = transform.forward * moveSpeed;
    }
}
