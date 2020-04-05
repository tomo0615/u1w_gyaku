using UnityEngine;

public class TargetSetter
{
    private Transform targetTransfom;

    private Transform _transform;

    public TargetSetter(Transform transform)
    {
        _transform = transform;
    }

    public Transform SetNearestTarget()
    {
        float minDistance = 999f;
        var buildingList = StageManager.Instance.GetBuildingList();

        //近い建物を全検索する
        foreach (Transform target in buildingList)
        {
            if (target == null) continue;

            float distance = Vector3.Distance(_transform.position, target.position);

            if (minDistance > distance)
            {
                minDistance = distance;

                targetTransfom = target;
            }
        }

        return targetTransfom;
    }
}
