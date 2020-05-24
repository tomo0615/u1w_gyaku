using System.Collections.Generic;
using UnityEngine;

public class UnitManager : SingletonMonoBehaviour<UnitManager>
{
    private List<BaseUnit> summonedUnitList = new List<BaseUnit>();

    [SerializeField]
    private GameEndPresenter _gameEndPresenter = null;

    [SerializeField]
    private UnitStorage _unitStorage = null;

    [field: SerializeField]
    public List<Transform> unitOkeList { get; private set; } = new List<Transform>();

    public void AddSummonedUnitList(BaseUnit unit)
    {
        summonedUnitList.Add(unit);
    }

    public void RemoveUnitList(BaseUnit unit)
    {
        summonedUnitList.Remove(unit);

        if(summonedUnitList.Count == 0 &&
           _unitStorage.IsGetableAllUnit())
        {
            _gameEndPresenter.OnGameEnd(isClear: false);
        }
    }

    public void SetTargetToAllUnit(Transform target)
    {
        foreach(BaseUnit unit in summonedUnitList)
        {
            unit.SetTarget(target);
        }
    }
}
