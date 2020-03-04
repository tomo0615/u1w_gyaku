using UnityEngine;
public enum UnitState
{
    Move,
    Attack
};

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseUnit : MonoBehaviour, IAttackable
{
    [SerializeField]
    private int hitPoint = 1;

    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    private UnitState currentState = UnitState.Move;

    [SerializeField]
    private AttackObject attackPrefab = null;

    [SerializeField]
    private float attackInterval = 2f;

    [SerializeField]
    private Animator _animator = null;

    private float attackIntervalSave = 0f;

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
    private void Update()
    {
        if(currentState == UnitState.Move)
        {
            MoveTartget();
        }
        else if(currentState == UnitState.Attack)
        {
            _rigidbody.velocity *= 0;
            AttackTarget();
        }

        //State変更
        if(Vector3.Distance(transform.position, attackTarget) <= 2f)
        {
            currentState = UnitState.Attack;
            _animator.Play("Attack");
        }
        else
        {
            currentState = UnitState.Move;
            _animator.Play("Move");
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

    protected void AttackTarget()
    {
        attackIntervalSave += Time.deltaTime;

        if(attackIntervalSave >= attackInterval)
        {
            Instantiate(attackPrefab, transform.position + transform.forward, Quaternion.identity);

            attackIntervalSave = 0f;
        }
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
}
