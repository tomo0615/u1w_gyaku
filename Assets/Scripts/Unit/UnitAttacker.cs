using UnityEngine;

namespace Unit
{
    public class UnitAttacker : MonoBehaviour
    {
        [SerializeField]
        private AttackObject attackObject = default;

        [SerializeField]
        private int attackPower = 1;

        [SerializeField]
        private float attackInterval = 2f;

        private float _attackIntervalSave = 0f;

        [SerializeField]
        private float _attackRange = 6f;

        public void AttackToTarget()
        {
            _attackIntervalSave += Time.deltaTime;

            if (!(_attackIntervalSave >= attackInterval)) return;
        
            attackObject.SetOriginPosition();

            attackObject.ActiveAttackObject(attackPower);

            _attackIntervalSave = 0f;
        }

        public bool IsAttackToTarget(Transform target)
        {
            var distance = Vector3.Distance(transform.position, target.position);

            return distance <= _attackRange;
        }
    }
}
