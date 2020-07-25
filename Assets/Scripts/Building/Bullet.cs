using UnityEngine;

namespace Building
{
    public class Bullet : MonoBehaviour
    {
        // プールしないならメンバ変数にしなくて良いかも
        private Rigidbody _rigidbody;

        private int _bulletPower;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            Destroy(gameObject, 10f);
        }

        public void SetShotVelocity(Vector3 velocity, int power)
        {
            _rigidbody.velocity = velocity;
            _bulletPower = power;
        }

        private void OnTriggerEnter(Collider other)
        {
            var attakable = other.GetComponent<IAttackable>();

            if (attakable == null) return;
            
            attakable.Attacked(_bulletPower);

            Destroy(gameObject);
        }
    }
}
