using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private PlayerRayCaster _playerRayCaster;

    private PlayerSummoner _playerSummoner;

    private PlayerPointer _playerPointer;

    [SerializeField]
    private UnitType _currentUnitType = UnitType.Normal;

    [SerializeField]
    private DrawArc _drawArc = default;

    private bool isSummonable = true;

    public void InitializePlayer()
    {
        Camera camera = Camera.main;

        _playerInput = new PlayerInput();

        _playerRayCaster = new PlayerRayCaster(camera, transform);

        _playerSummoner = GetComponent<PlayerSummoner>();

        _playerPointer = GetComponent<PlayerPointer>();

        _playerPointer.Initialize();
    }


    private void OnTriggerEnter(Collider other)
    {
        var area = other.GetComponent<AttackRangeArea>();

        if(area != null)
        {
            isSummonable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var area = other.GetComponent<AttackRangeArea>();

        if (area != null)
        {
            isSummonable = true;
        }
    }

    public void UpdatePlayerAction()
    {
        var okeList = UnitManager.Instance.unitOkeList;

        //軌跡の表示
        _drawArc.DrawLine(okeList[(int)_currentUnitType].position, transform.position);

        Vector3 mousePosition
            = _playerRayCaster.GetPositionByRay(_playerInput.MouseDirection);

        transform.position = mousePosition;

        //Unitの選択
        if (_playerInput.IsSelectSlot() >= 0)
        {
            _currentUnitType = (UnitType)_playerInput.IsSelectSlot();
        }

        if (isSummonable == false) return;
        
        //召喚
        if (_playerInput.IsSummonSetting)
        {
            _playerSummoner.SummonSetting(mousePosition, _currentUnitType);
        }
        else if (_playerInput.IsSummon)
        {
            _playerSummoner.SummonUnit();
        }

        //Unitへ命令
        if (_playerInput.IsAllAttack)
        {
            Transform targetPosition
                 = _playerRayCaster.GetRayHitObject(_playerInput.MouseDirection);

            UnitManager.Instance.SetTargetToAllUnit(targetPosition);
        }
    }
}
