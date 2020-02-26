using UnityEngine;

public abstract class BaseUnit : MonoBehaviour , IAttackable
{
    [SerializeField]
    private int hitPoint = 1;

    public void Attacked()
    {
        hitPoint--;

        if (hitPoint <= 0)
        { 
            // TODO:撃破時Effect

            gameObject.SetActive(false);
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.ApplyDamage();
        }
    }
}
