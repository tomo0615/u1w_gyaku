using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Building;
using GUI.GameEnd;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    private List<Transform> buildingTransformList = new List<Transform>();

    [SerializeField]
    private GameEndPresenter _gameEndPresenter = default;

    private CameraController _cameraController;

    protected override void Awake()
    {
        _cameraController = new CameraController(Camera.main);

        AddToListBuildingTransform();
    }

    private void AddToListBuildingTransform()
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

        //Cameraの揺れ
        _cameraController.ShakeCamera(1.0f);

        if (buildingTransformList.Count == 0)
        {
            _gameEndPresenter.OnGameEnd(isClear:true);
        }
    }
}
