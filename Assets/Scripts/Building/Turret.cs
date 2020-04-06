using UnityEngine;

public class Turret :　BaseBuilding
{
    private TurretShooter _turretShooter;

    private TurretRotater _turretRotater;

    [SerializeField]
    private Transform turretTransform = default;

    private AttackRangeArea attackRangeArea;

    private Vector3 targetDirection = Vector3.zero;

    private void Awake()
    {
        _turretShooter = GetComponent<TurretShooter>();

        _turretRotater = new TurretRotater(turretTransform);

        attackRangeArea = GetComponentInChildren<AttackRangeArea>();
    }

    private void Update()
    {
        SetTargetDirection();

        if (attackRangeArea.IsAttackable())
        {
            _turretRotater.LookTargtDirection(targetDirection);

            _turretShooter.ShotBullet(targetDirection);
        }
    }

    private void SetTargetDirection()
    {
        Vector3 attackTargetPosition = attackRangeArea.GetCurrentTarget();

        attackTargetPosition.y = turretTransform.position.y;

        targetDirection = attackTargetPosition - turretTransform.position;
    }
}
