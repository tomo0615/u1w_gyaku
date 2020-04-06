using UnityEngine;

public class TurretShooter : MonoBehaviour
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

    private float elapsedTimeValue = 0;

    public void ShotBullet(Vector3 targetDirection)
    {
        elapsedTimeValue += Time.deltaTime;

        if (elapsedTimeValue >= shotInterval)
        {
            Bullet bullet
                = Instantiate(bulletPrefab,
                shotTransform.position,
                shotTransform.rotation);//varistorの弾が

            bullet.SetShotVelocity(targetDirection.normalized * bulletSpeed, bulletPower);

            elapsedTimeValue = 0;
        }
    }
}
