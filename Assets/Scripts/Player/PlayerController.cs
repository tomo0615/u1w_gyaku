using Building;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private PlayerRayCaster _playerRayCaster;

    private PlayerSummoner _playerSummoner;

    private PlayerPointer _playerPointer;

    private UnitType _currentUnitType = UnitType.Normal;

    [SerializeField]
    private DrawArc drawArc = default;

    private bool _isSummonable = true;

    public void InitializePlayer()
    {
        _playerInput = new PlayerInput();

        _playerRayCaster = new PlayerRayCaster(Camera.main, transform);

        _playerSummoner = GetComponent<PlayerSummoner>();

        _playerPointer = GetComponent<PlayerPointer>();

        _playerPointer.Initialize();
    }

    private void OnTriggerStay(Collider other)
    {
        var area = other.GetComponent<AttackRangeArea>();

        if(area != null)
        {
            _isSummonable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var area = other.GetComponent<AttackRangeArea>();

        if (area != null)
        {
            _isSummonable = true;
        }
    }

    public void UpdatePlayerAction()
    {
        var okeList = UnitManager.Instance.unitOkeList;

        //軌跡の表示
        drawArc.DrawLine(okeList[(int)_currentUnitType].position, transform.position);

        var mousePosition
            = _playerRayCaster.GetPositionByRay(_playerInput.MouseDirection);

        transform.position = mousePosition;

        //Unitの選択
        if (_playerInput.IsSelectSlot())
        {
            _currentUnitType = (UnitType)_playerInput.GetSelectSlot();
        }

        //Unitへ命令
        if (_playerInput.IsAllAttack)
        {
            var targetPosition
                 = _playerRayCaster.GetRayHitObject(_playerInput.MouseDirection);

            UnitManager.Instance.SetTargetToAllUnit(targetPosition);
        }

        if (_isSummonable == false) return;

        //召喚
        if (_playerInput.IsSummonSetting)
        {
            _playerSummoner.SummonSetting(mousePosition, _currentUnitType);
        }
        else if (_playerInput.IsSummon)
        {
            _playerSummoner.SummonUnit();
        }
    }
}
