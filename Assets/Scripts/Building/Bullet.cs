using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    public void SetShotVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        var attakable = other.GetComponent<IAttackable>();

        if(attakable != null)
        {
            attakable.Attacked();

            Destroy(gameObject);
        }
    }
}
