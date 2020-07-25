using UnityEngine;

public class UnitMover
{
    // readonly 追加したい
    private Transform _transform;

    // readonly 追加したい
    private Rigidbody _rigidbody;

    public UnitMover(Transform transform, Rigidbody rigidbody)
    {
        _transform = transform;

        _rigidbody = rigidbody;
    }

    // Target
    public void MoveToTartget(Transform targetTransform, float moveSpeed)
    {
        _transform.LookAt(targetTransform);

        _rigidbody.velocity = _transform.forward * moveSpeed;
    }

    public void StopMove()
    {
        _rigidbody.velocity *= 0;
    }
}
