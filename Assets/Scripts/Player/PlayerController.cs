using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private PlayerRayCaster _playerRayCaster;

    private PlayerSummoner _playerSummoner;

    private PlayerUnitController _playerUnitController;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerRayCaster = new PlayerRayCaster();

        _playerSummoner = GetComponent<PlayerSummoner>();

        _playerUnitController = new PlayerUnitController();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //入力感知
        _playerInput.Inputting();

        //召喚

        //Unitへ命令
    }
}
