using UnityEngine;

public class UnitAttacker : MonoBehaviour
{
    [SerializeField]
    private AttackObject attackPrefab = null;

    [SerializeField]
    private int attackPower = 1;

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
            var attackObject 
                = Instantiate(attackPrefab,
                transform.position + transform.forward * 3,
                transform.rotation);

            attackObject.Initialize(attackPower);

            attackIntervalSave = 0f;
        }
    }

    public bool IsAttackToTarget(Vector3 targetPosition)
    {
        return Vector3.Distance(transform.position, targetPosition)
            <= attackRangeValue;
    }
}
