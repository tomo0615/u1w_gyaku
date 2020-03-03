using UnityEngine;

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
        //一番近い建物をTargetにする
        float minDistance = 999f;

        foreach (Transform target in StageManager.Instance.GetBuildingList())
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (minDistance > distance)
            {
                minDistance = distance;

                SetTarget(target);
            }
        }
    }

    public void SetTarget(Transform target)
    {
        Vector3 moveDirection = (target.position - transform.position).normalized;
        attackTarget = target.position - moveDirection;

        attackTarget.y = transform.position.y;
    }

    protected void MoveTartget()
    {
        transform.LookAt(attackTarget);

        _rigidbody.velocity = transform.forward * moveSpeed;
    }

    public void Attacked(int damageValue)
    {
        hitPoint -= damageValue;

        if (hitPoint <= 0)
        { 
            // TODO:撃破時Effect

            gameObject.SetActive(false);
        }
    }
    /*TODO:攻撃するObjectにつける
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.ApplyDamage();
        }
    }
    */
}
