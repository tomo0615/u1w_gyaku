using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private PlayerRayCaster _playerRayCaster;

    private PlayerSummoner _playerSummoner;

    private PlayerUnitController _playerUnitController;

    private TrailRenderer trail;

    private void Awake()
    {
        Camera camera = Camera.main;

        _playerInput = new PlayerInput();

        _playerRayCaster = new PlayerRayCaster(camera, transform);

        _playerSummoner = GetComponent<PlayerSummoner>();

        _playerUnitController = new PlayerUnitController();

        trail = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        trail.enabled = false;
    }

    private void Update()
    {
        Vector3 mousePotion
            = _playerRayCaster.GetPositionByRay(_playerInput.MouseDirection);

        transform.position = mousePotion;

        //召喚
        if (_playerInput.IsSummonSetting)
        {
            _playerSummoner.SummonSetting(mousePotion);

            trail.enabled = true;
        }
        else if (_playerInput.IsSummon)
        {
            _playerSummoner.SummonUnit();

            trail.Clear();
            trail.enabled = false;
        }

        //Unitへ命令
    }
}
