using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitBullet : AttackObject
{
    [SerializeField]
    private float moveSpeed = 10f;

    private Rigidbody _rigidbody;

    public override void Initialize(int power)
    {
        base.Initialize(power);

        SetVelocity();
    }

    private void SetVelocity()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.velocity = transform.forward * moveSpeed;
    }
}
