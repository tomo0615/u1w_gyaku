using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    private List<Transform> buildingTransformList = new List<Transform>();

    [SerializeField]
    private GameEndPresenter _gameEndPresenter = default;
    protected override void Awake()
    {
        SetStageObjectPositions();
    }

    private void SetStageObjectPositions()
    {
        var buildingList = GetComponentsInChildren<BaseBuilding>().ToList();

        foreach(var building in buildingList)
        {
            buildingTransformList.Add(building.transform);
        }
    }

    public List<Transform> GetBuildingList()
    {
        return buildingTransformList;
    }

    public void RemoveAtBuilding(BaseBuilding building)
    {
        buildingTransformList.Remove(building.transform);

        if (buildingTransformList.Count == 0)
        {
            //GameClear! テスト済み
            _gameEndPresenter.OnGameEnd(isClear:true);
        }
    }
}
