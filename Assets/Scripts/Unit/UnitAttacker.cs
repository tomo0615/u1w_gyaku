using UnityEngine;

public class UnitAttacker : MonoBehaviour
{
    [SerializeField]
    private AttackObject attackPrefab = null;

    [SerializeField]
    private float attackInterval = 2f;

    [SerializeField]
    private float attackRangeValue = 4.0f;

    private float attackIntervalSave = 0f;

    public void AttackToTarget()
    {
        attackIntervalSave += Time.deltaTime;

        if (attackIntervalSave >= attackInterval)
        {
            Instantiate(attackPrefab,
                transform.position + transform.forward * 2,
                transform.rotation);

            attackIntervalSave = 0f;
        }
    }

    public bool IsAttackToTarget(Vector3 targetPosition)
    {
        return Vector3.Distance(transform.position, targetPosition)
            <= attackRangeValue;
    }

}
