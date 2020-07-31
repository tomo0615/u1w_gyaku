using UnityEngine;

namespace Building
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private int _bulletPower;

        private const float LifeTime = 5f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            Destroy(gameObject, LifeTime);
        }

        public void SetShotVelocity(Vector3 velocity, int power)
        {
            _rigidbody.velocity = velocity;
            _bulletPower = power;
        }

        private void OnTriggerEnter(Collider other)
        {
            var attackable = other.GetComponent<IAttackable>();

            if (attackable == null) return;
            
            attackable.Attacked(_bulletPower);

            Destroy(gameObject);
        }
    }
}
