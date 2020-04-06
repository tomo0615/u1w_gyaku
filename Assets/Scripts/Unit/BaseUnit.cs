using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UnitAttacker))]
public abstract class BaseUnit : MonoBehaviour, IAttackable
{
    private UnitMover _unitMover;

    private UnitAttacker _unitAttacker;

    private TargetSetter _targetSetter;

    [SerializeField]
    private int hitPoint = 1;

    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    private UnitActionState currentState = UnitActionState.Move;

    [SerializeField]
    private Animator _animator = null;

    private Transform attackTarget;

    private void Awake()
    {
        _unitMover = new UnitMover(transform, GetComponent<Rigidbody>());

        _unitAttacker = GetComponent<UnitAttacker>();

        _targetSetter = new TargetSetter(transform);
    }

    private void Update()
    {
        if (attackTarget == null)
        {
            attackTarget = _targetSetter.SetNearestTarget();
        }

        UpdateAnimation();

        //Action
        if (currentState == UnitActionState.Move)
        {
            _unitMover.MoveToTartget(attackTarget, moveSpeed);
        }
        else if(currentState == UnitActionState.Attack)
        {
            _unitMover.StopMove();

           _unitAttacker.AttackToTarget();
        }
        else
        {
            return;
        }
    }

    private void UpdateAnimation()
    {
        //距離でState変更
        if (_unitAttacker.IsAttackToTarget(attackTarget.position))
        {
            currentState = UnitActionState.Attack;
        }
        else
        {
            currentState = UnitActionState.Move;
        }

        _animator.Play(currentState.ToString());
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
