using UnityEngine;

public class GameStateManager : StateMachine<GameState>
{
    [SerializeField]
    private UnitStorage _unitStorage = default;

    [SerializeField]
    private UnitSelectView _unitSelectView = default;

    [SerializeField]
    private StartPresenter _startPresenter = default;

    [SerializeField]
    private PlayerController _playerController = default;

    [SerializeField]
    private GameEndPresenter _gameEndPresenter = default;

    private void Awake()
    {
        InitializeStateMachine();
    }

    private void Start()
    {
        GoToState(GameState.Setting);
    }

    private void InitializeStateMachine()
    {
        //Setting
        {
            var state = new State<GameState>(GameState.Setting);
            state.SetUpAction = OnSetUpSetting;
            state.UpdateAction = OnUpdateSetting;
            AddState(state);
        }
        //Game
        {
            var state = new State<GameState>(GameState.Game);
            state.SetUpAction = OnSetUpGame;
            state.UpdateAction = OnUpdateGame;
            AddState(state);
        }
        //Finish
        {
            var state = new State<GameState>(GameState.Finish);
            state.SetUpAction = OnSetUpFinish;
            state.UpdateAction = OnUpdateFinish;
            AddState(state);
        }
    }

    #region SettingMethod
    private void OnSetUpSetting()
    {
        //UnitSelectUIの表示
        _unitSelectView.ActiveUnitSelectUI(true);
    }

    private void OnUpdateSetting()
    {
        if (_unitStorage.IsFullHasUnitList)
        {
            _unitSelectView.ActiveUnitSelectUI(false);
            GoToState(GameState.Game);
        }
    }
    #endregion

    #region GameMethod

    private void OnSetUpGame()
    {
        _startPresenter.OnGameStart();
    }

    private void OnUpdateGame()
    {
        //Playerを使えるようにする
        _playerController.UpdatePlayerAction();

        if (_gameEndPresenter.IsGameEnd)
        {
            GoToState(GameState.Finish);
        }
    }
    #endregion

    #region FinishMethod
    private void OnSetUpFinish()
    {
        //Debug.Log("Finish");
    }
    private void OnUpdateFinish()
    {
        //Debug.Log("Finish");
    }

    #endregion 
}
