using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    private List<Transform> stageObjectList = new List<Transform>();

    protected override void Awake()
    {
        SetStageObjectPositions();
    }

    private void SetStageObjectPositions()
    {
        stageObjectList = GetComponentsInChildren<Transform>().ToList();
    }

    public List<Transform> GetStageObjectList()
    {
        return stageObjectList;
    }
}
