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
    private float attackRange = 3f;　//中心からの半径

    private AttackRangeArea attackRangeArea;

    private Vector3 targetPosition;

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
                targetPosition = attackRangeArea.GetCurrentTarget();
                targetPosition.y = 0;
            }

            bullet.SetShotVelocity(targetPosition.normalized * bulletSpeed);

            yield return new WaitForSeconds(shotInterval);
        }
    }

    private bool IsShotable()
    {
        return attackRangeArea.unitList.Count > 0;
    }
}
