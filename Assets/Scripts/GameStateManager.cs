using UnityEngine;

public class GameStateManager : StateMachine<GameState>
{
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
            state.UpdateAction = OnUpdateGame;
            AddState(state);
        }
        //Finish
        {
            var state = new State<GameState>(GameState.Finish);
            state.SetUpAction = OnSetUpFinish;
            AddState(state);
        }
    }

    #region SettingMethod
    private void OnSetUpSetting()
    {
        StartCoroutine(_startPresenter.OnGameStart());
    }

    private void OnUpdateSetting()
    {
        if (_startPresenter.IsCompleteSetting())
        {
            GoToState(GameState.Game);
        }
    }
    #endregion

    #region GameMethod
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

    #endregion 
}
