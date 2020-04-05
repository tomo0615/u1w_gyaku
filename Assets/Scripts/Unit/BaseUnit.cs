using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UnitAttacker))]
public abstract class BaseUnit : MonoBehaviour, IAttackable
{
    private UnitMover _unitMover;

    private UnitAttacker _unitAttacker;

    [SerializeField]
    private int hitPoint = 1;

    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    private UnitActionState currentState = UnitActionState.Move;

    [SerializeField]
    private Animator _animator = null;

    private Transform attackTarget;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _unitMover = new UnitMover(transform, _rigidbody);

        _unitAttacker = GetComponent<UnitAttacker>();
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

        if (currentState == UnitActionState.Move)
        {
            _unitMover.MoveToTartget(attackTarget, moveSpeed);
        }
        else if(currentState == UnitActionState.Attack)
        {
            _rigidbody.velocity *= 0;

           _unitAttacker.AttackToTarget();
        }
        else
        {
            return;
        }

        //State変更
        if(_unitAttacker.IsAttackToTarget(attackTarget.position))
        {
            currentState = UnitActionState.Attack;
            _animator.Play("Attack");
        }
        else
        {
            currentState = UnitActionState.Move;
            _animator.Play("Move");
        }
    }

    private void SetNearestTarget()
    {        
        float minDistance = 999f;
        var buildingList = StageManager.Instance.GetBuildingList();

        if(buildingList.Count == 0) currentState = UnitActionState.Freeze;

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
