using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private PlayerRayCaster _playerRayCaster;

    private PlayerSummoner _playerSummoner;

    private PlayerUnitController _playerUnitController;


    private void Awake()
    {
        Camera camera = Camera.main;

        _playerInput = new PlayerInput();

        _playerRayCaster = new PlayerRayCaster(camera, transform);

        _playerSummoner = GetComponent<PlayerSummoner>();

        _playerUnitController = new PlayerUnitController();
    }

    private void Update()
    {
        //召喚
        if (_playerInput.IsSummonSetting)
        {
            Vector3 mousePotion
                = _playerRayCaster.GetPositionByRay(_playerInput.MouseDirection);

            _playerSummoner.SummonSetting(mousePotion);
        }
        else if (_playerInput.IsSummon)
        {
            _playerSummoner.SummonUnit();
        }

        //Unitへ命令
    }
}
