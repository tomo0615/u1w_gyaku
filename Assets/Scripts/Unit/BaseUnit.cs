using UnityEngine;
public enum UnitState
{
    Move,
    Attack,
    Freeze,
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

    private Transform attackTarget;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SetNearestTarget();
    }

    private void Update()
    {
        if (attackTarget == null)
        {
            SetNearestTarget();
        }

        if (currentState == UnitState.Move)
        {
            MoveToTartget();
        }
        else if(currentState == UnitState.Attack)
        {
            _rigidbody.velocity *= 0;

            AttackTarget();
        }
        else
        {
            return;
        }

        //State変更
        if(Vector3.Distance(transform.position, attackTarget.position) <= 4f)
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

    private void SetNearestTarget()
    {        
        float minDistance = 999f;
        var buildingList = StageManager.Instance.GetBuildingList();

        if(buildingList.Count == 0) currentState = UnitState.Freeze;

        //近い建物を全検索する
        foreach (Transform target in buildingList)
        {
            if (target == null) continue;

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
        attackTarget = target;
    }

    protected void MoveToTartget()
    {
        transform.LookAt(attackTarget);

        _rigidbody.velocity = transform.forward * moveSpeed;
    }

    protected void AttackTarget()
    {
        attackIntervalSave += Time.deltaTime;

        if(attackIntervalSave >= attackInterval)
        {
            Instantiate(attackPrefab, transform.position + transform.forward * 2, transform.rotation);

            attackIntervalSave = 0f;
        }
    }

    public void Attacked(int damageValue)
    {
        hitPoint -= damageValue;

        if (hitPoint <= 0)
        {
            GameEffectManager.Instance
                .OnGenelateEffect(transform.position, EffectType.UnitDead);

            UnitManager.Instance.RemoveUnitList(this);

            gameObject.SetActive(false);
        }
    }
}
