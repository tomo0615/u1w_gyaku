using System.Collections.Generic;
using UnityEngine;

public class UnitManager : SingletonMonoBehaviour<UnitManager>
{
    private List<BaseUnit> summonedUnitList = new List<BaseUnit>();

    [SerializeField]
    private GameEndPresenter _gameEndPresenter = null;

    [SerializeField]
    private UnitCountPresenter _unitCountPresenter = null;

    [SerializeField]
    private UnitStorage _unitStorage = null;

    private void Start()
    {
        //_unitCountPresenter.Initialize(unitCount);
    }

    public void AddSummonedUnitList(BaseUnit unit)
    {
        summonedUnitList.Add(unit);

        //_unitCountPresenter.OnChangeUnitCount(unitCount);
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
