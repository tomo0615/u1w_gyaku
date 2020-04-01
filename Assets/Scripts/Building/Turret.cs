using System.Collections;
using UnityEngine;

public class Turret :　BaseBuilding
{
    [SerializeField]
    private Bullet bulletPrefab = null;

    [SerializeField]
    private float shotInterval = 1f;

    [SerializeField]
    private float bulletSpeed = 10f;

    [SerializeField]
    private int bulletPower = 2;

    [SerializeField]
    private Transform turretTransform = default;

    [SerializeField]
    private Transform shotTransform = default;

    private AttackRangeArea attackRangeArea;

    private Vector3 targetDirection;

    private void Awake()
    {
        attackRangeArea = GetComponentInChildren<AttackRangeArea>();
    }

    protected override void Start()
    {
        base.Start();

        StartCoroutine(ShotBullet());
    }

    private void Update()
    {
        LookTargtDirection();
    }

    private void LookTargtDirection()
    { 
        Vector3 attackTargetPosition = attackRangeArea.GetCurrentTarget();
        
        if (attackTargetPosition == Vector3.zero)
        {
            return;
        }

        attackTargetPosition.y = turretTransform.position.y;
        targetDirection = attackTargetPosition - turretTransform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        turretTransform.rotation = Quaternion.Slerp(turretTransform.rotation, targetRotation, 0.3f);
    }

    private IEnumerator ShotBullet()
    {
        while (true)
        {
            if (attackRangeArea.IsAttackable())
            {
                Bullet bullet = Instantiate(bulletPrefab, shotTransform.position, turretTransform.rotation);

                bullet.SetShotVelocity(targetDirection.normalized * bulletSpeed, bulletPower);
            }

            yield return new WaitForSeconds(shotInterval);
        }
    }
}
