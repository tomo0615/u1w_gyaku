using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    private List<Transform> buildingList;

    protected override void Awake()
    {
        SetStageObjectPositions();
    }

    private void SetStageObjectPositions()
    {
        buildingList = GetComponentsInChildren<Transform>().ToList();

        buildingList.Remove(transform);
    }

    public List<Transform> GetBuildingList()
    {
        return buildingList;
    }
}
