using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseUnit : MonoBehaviour , IAttackable
{
    [SerializeField]
    private int hitPoint = 1;

    [SerializeField]
    private float moveSpeed = 10;

    private Vector3 attackTarget;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SetTarget();
    }

    private void SetTarget()
    {
        float minDistance = 999f;

        foreach (Transform target in StageManager.Instance.GetBuildingList())
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (minDistance > distance)
            {
                minDistance = distance;

                Vector3 moveDirection = (target.position - transform.position).normalized * 3;
                attackTarget = target.position - moveDirection;

                attackTarget.y = 0;
            }
        }
    }

    public void SetTarget(Transform target)
    {
        attackTarget = target.position;
    }


    protected void MoveTartget()
    {
        transform.LookAt(attackTarget);
        _rigidbody.velocity = transform.forward * moveSpeed;
    }

    public void Attacked()
    {
        hitPoint--;

        if (hitPoint <= 0)
        { 
            // TODO:撃破時Effect

            gameObject.SetActive(false);
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
