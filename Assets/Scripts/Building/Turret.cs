using Building;
using UnityEngine;

public class Turret :　BaseBuilding
{
    private TurretShooter _turretShooter;

    private TurretRotater _turretRotater;

    [SerializeField]
    private Transform turretTransform = default;

    private AttackRangeArea _attackRangeArea;

    private Vector3 _targetDirection = Vector3.zero;

    private void Awake()
    {
        _turretShooter = GetComponent<TurretShooter>();

        _turretRotater = new TurretRotater(turretTransform);

        _attackRangeArea = GetComponentInChildren<AttackRangeArea>();
    }

    private void Update()
    {
        SetTargetDirection();

        // ! か != false は統一した方が良い
        if (!_attackRangeArea.IsAttackable()) return;
        
        _turretRotater.LookTargetDirection(_targetDirection);

        _turretShooter.ShotBullet(_targetDirection);
    }

    // 返り値 vector の関数にする方が好き
    private void SetTargetDirection()
    {
        Vector3 attackTargetPosition = _attackRangeArea.GetCurrentTarget();

        attackTargetPosition.y = turretTransform.position.y;

        _targetDirection = attackTargetPosition - turretTransform.position;
    }
}
