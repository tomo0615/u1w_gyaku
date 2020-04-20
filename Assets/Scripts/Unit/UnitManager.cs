using System.Collections.Generic;
using UnityEngine;

public class UnitManager : SingletonMonoBehaviour<UnitManager>
{
    private List<BaseUnit> unitList = new List<BaseUnit>();

    [SerializeField]
    private int unitCount = 10;

    [SerializeField]
    private GameEndPresenter _gameEndPresenter = null;

    [SerializeField]
    private UnitCountPresenter _unitCountPresenter = null;

    private void Start()
    {
        _unitCountPresenter.Initialize(unitCount);
    }

    public void AddUnitList(BaseUnit unit)
    {
        unitList.Add(unit);

        unitCount--;
        _unitCountPresenter.OnChangeUnitCount(unitCount);
    }

    public void RemoveUnitList(BaseUnit unit)
    {
        unitList.Remove(unit);

        if(unitList.Count == 0 &&
           SummonableUnit() == false)
        {
            _gameEndPresenter.OnGameEnd(isClear: false);
        }
    }

    public void SetTargetToAllUnit(Transform target)
    {
        foreach(BaseUnit unit in unitList)
        {
            unit.SetTarget(target);
        }
    }

    public bool SummonableUnit()
    {
        return unitCount > 0; 
    }
}
