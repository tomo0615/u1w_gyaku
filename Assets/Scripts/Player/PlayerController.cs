using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private PlayerRayCaster _playerRayCaster;

    private PlayerSummoner _playerSummoner;

    private Vector3 _mousePosition;

    [SerializeField]
    private UnitType _currentUnitType = UnitType.Normal;

    [SerializeField]
    private SpriteRenderer _pointer = default;

    [SerializeField]
    private DrawArc _drawArc = default;

    [SerializeField]
    private GameObject furoOke = default;

    public void InitializePlayer()
    {
        Camera camera = Camera.main;

        _playerInput = new PlayerInput();

        _playerRayCaster = new PlayerRayCaster(camera, transform);

        _playerSummoner = GetComponent<PlayerSummoner>();

        _pointer.enabled = true;
    }

    public void UpdatePlayerAction()
    {
        _drawArc.DrawLine(furoOke.transform.position, transform.position);//okeの座標を変える

        _mousePosition
            = _playerRayCaster.GetPositionByRay(_playerInput.MouseDirection);

        transform.position = _mousePosition;

        //Unitの選択
        if (_playerInput.IsSelectSlot() >= 0)
        {
            _currentUnitType = (UnitType)_playerInput.IsSelectSlot();
        }

        //召喚
        if (_playerInput.IsSummonSetting)
        {
            _playerSummoner.SummonSetting(_mousePosition, _currentUnitType);
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

            if (targetPosition == null)
            {
                return;
            }

            UnitManager.Instance.SetTargetToAllUnit(targetPosition);
        }
    }
}
