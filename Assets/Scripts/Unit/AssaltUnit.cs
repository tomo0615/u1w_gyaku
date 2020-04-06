using UnityEngine;

[RequireComponent(typeof(UnitAttacker))]
public class AssaltUnit : BaseUnit
{
    /*
    private UnitMover _unitMover;

    private UnitAttacker _unitAttacker;

    private TargetSetter _targetSetter;

    private void Awake()
    {
        _unitMover = new UnitMover(transform, GetComponent<Rigidbody>());

        _unitAttacker = GetComponent<UnitAttacker>();

        _targetSetter = new TargetSetter(transform);
    }

    private void Start()
    {
        attackTarget = _targetSetter.SetNearestTarget();
    }
    */
}
