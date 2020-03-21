using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private int bulletPower;

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
        bulletPower = power;
        _rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        var attakable = other.GetComponent<IAttackable>();

        if(attakable != null)
        {
            attakable.Attacked(bulletPower);

            Destroy(gameObject);
        }
    }
}
