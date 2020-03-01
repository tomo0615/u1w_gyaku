using System.Collections;
using System.Collections.Generic;
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

    private List<BaseUnit> unitList = new List<BaseUnit>();

    private void Start()
    {
        StartCoroutine(ShotBullet());
    }

    private IEnumerator ShotBullet()
    {
        //if (IsShotable())
        //{
        while (true)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.SetShotVelocity(transform.forward * bulletSpeed);

            yield return new WaitForSeconds(shotInterval);
        }
      //  }
    }

    private bool IsShotable()
    {
        return unitList.Count > 0;
    }
}
