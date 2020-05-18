using UnityEngine;

public class UnitAttacker : MonoBehaviour
{
    [SerializeField]
    private AttackObject attackObject = default;

    [SerializeField]
    private int attackPower = 1;

    [SerializeField]
    private float attackInterval = 2f;

    private float attackIntervalSave = 0f;

    public void AttackToTarget()
    {
        attackIntervalSave += Time.deltaTime;

        if (attackIntervalSave >= attackInterval)
        {
            attackObject.SetOriginPosition();

            attackObject.ActiveAttackObject(attackPower);

            attackIntervalSave = 0f;
        }
    }
}
