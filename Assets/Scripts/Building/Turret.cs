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

    private Vector3 targetDirection;

    private void Awake()
    {
        attackRangeArea = GetComponentInChildren<AttackRangeArea>();
    }
    private void Start()
    {
        StartCoroutine(ShotBullet());
    }



    private IEnumerator ShotBullet()
    {
        while (true)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            if (attackRangeArea.IsAttackable())
            {
                Vector3 attackTargetPosition = attackRangeArea.GetCurrentTarget();
                attackTargetPosition.y = transform.position.y;

                targetDirection = attackTargetPosition - transform.position;

                bullet.SetShotVelocity(targetDirection.normalized * bulletSpeed, bulletPower);

                transform.LookAt(attackTargetPosition); //TODO:Slerpを使う
            }

            yield return new WaitForSeconds(shotInterval);
        }
    }
}
