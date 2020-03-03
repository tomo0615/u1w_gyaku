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

            if (IsShotable())
            {
                targetDirection = attackRangeArea.GetCurrentTarget() - transform.position;
                targetDirection.y = 0;
            }

            bullet.SetShotVelocity(targetDirection.normalized * bulletSpeed, bulletPower);

            yield return new WaitForSeconds(shotInterval);
        }
    }

    private bool IsShotable()
    {
        return attackRangeArea.unitList.Count > 0;
    }
}
