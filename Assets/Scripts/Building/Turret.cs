using Building;
using UnityEngine;

public class Turret :　BaseBuilding
{
    private TurretShooter _turretShooter;

    private TurretRotater _turretRotater;

    [SerializeField]
    private Transform turretTransform = default;

    private AttackRangeArea _attackRangeArea;
    
    private void Awake()
    {
        _turretShooter = GetComponent<TurretShooter>();

        _turretRotater = new TurretRotater(turretTransform);

        _attackRangeArea = GetComponentInChildren<AttackRangeArea>();
    }

    private void Update()
    {
        var target = SetTargetDirection();

        if (!_attackRangeArea.IsAttackable()) return;
        
        _turretRotater.LookTargetDirection(target);

        _turretShooter.ShotBullet(target);
    }

    private Vector3 SetTargetDirection()
    {
        var attackTargetPosition = _attackRangeArea.GetCurrentTarget();

        attackTargetPosition.y = turretTransform.position.y;

        return attackTargetPosition - turretTransform.position;
    }
}
