using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private PlayerRayCaster _playerRayCaster;

    private PlayerSummoner _playerSummoner;

    [SerializeField]
    private UnitManager _unitManager = null;

    private void Awake()
    {
        Camera camera = Camera.main;

        _playerInput = new PlayerInput();

        _playerRayCaster = new PlayerRayCaster(camera, transform);

        _playerSummoner = GetComponent<PlayerSummoner>();
    }

    private void Update()
    {
        var mousePosition
            = _playerRayCaster.GetPositionByRay(_playerInput.MouseDirection);

        transform.position = mousePosition;

        //Unitへ命令
        if (_playerInput.IsAllAttack)
        {
            Transform targetPosition
                 = _playerRayCaster.GetRayHitObject(_playerInput.MouseDirection);

            if (targetPosition == null)
            {
                return;
            }

            _unitManager.SetTargetToAllUnit(targetPosition);
        }

        if (_unitManager.SummonableUnit() == false) return;

        //召喚
        if (_playerInput.IsSummonSetting)
        {
            _playerSummoner.SummonSetting(mousePosition);
        }
        else if (_playerInput.IsSummon)
        {
            _playerSummoner.SummonUnit();
        }
    }
}
