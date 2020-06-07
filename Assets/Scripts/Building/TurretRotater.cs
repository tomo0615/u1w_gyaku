using UnityEngine;

namespace Building
{
    public class TurretRotater
    {
        private Transform _transform;

        public TurretRotater(Transform transform)
        {
            _transform = transform;
        }

        public void LookTargetDirection(Vector3 targetDirection)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, 0.30f);
        }
    }
}
