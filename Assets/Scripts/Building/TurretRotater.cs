using UnityEngine;

namespace Building
{
    public class TurretRotater
    {
        // readonly にしたい
        private Transform _transform;

        public TurretRotater(Transform transform)
        {
            _transform = transform;
        }

        public void LookTargetDirection(Vector3 targetDirection)
        {
            var targetRotation = Quaternion.LookRotation(targetDirection);

            // マジックナンバーは定数化したい
            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, 0.30f);
        }
    }
}
