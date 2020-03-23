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
    private Transform shotTransform = default;

    private AttackRangeArea attackRangeArea;

    private Vector3 attackTargetPosition;

    private Vector3 targetDirection;

    private void Awake()
    {
        attackRangeArea = GetComponentInChildren<AttackRangeArea>();
    }
    private void Start()
    {
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

        attackTargetPosition.y = transform.position.y;
        targetDirection = attackTargetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.3f);
    }

    private IEnumerator ShotBullet()
    {
        while (true)
        {
            if (attackRangeArea.IsAttackable())
            {
                Bullet bullet = Instantiate(bulletPrefab, shotTransform.position, transform.rotation);

                bullet.SetShotVelocity(targetDirection.normalized * bulletSpeed, bulletPower);
            }

            yield return new WaitForSeconds(shotInterval);
        }
    }
}
