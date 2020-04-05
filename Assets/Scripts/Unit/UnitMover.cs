using UnityEngine;

public class UnitMover
{
    private Transform _transform;

    private Rigidbody _rigidbody;

    public UnitMover(Transform transform, Rigidbody rigidbody)
    {
        _transform = transform;

        _rigidbody = rigidbody;
    }

    public void MoveToTartget(Transform targetTransform, float moveSpeed)
    {
        _transform.LookAt(targetTransform);

        _rigidbody.velocity = _transform.forward * moveSpeed;
    }
}
