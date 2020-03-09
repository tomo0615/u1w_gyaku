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
        targetDirection = attackTargetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.3f);
    }

    //TODO：機能を分割する
    private IEnumerator ShotBullet()
    {
        while (true)
        {
            if (attackRangeArea.IsAttackable())
            {
                Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                attackTargetPosition = attackRangeArea.GetCurrentTarget();
                attackTargetPosition.y = transform.position.y;

                bullet.SetShotVelocity(targetDirection.normalized * bulletSpeed, bulletPower);
            }

            yield return new WaitForSeconds(shotInterval);
        }
    }
}
