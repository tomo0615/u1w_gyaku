using GUI.GameEnd;
using UnityEngine;
using Zenject;

public class GameStateManager : StateMachine<GameState>
{
    [Inject]
    private readonly FadeSceneLoader.FadeSceneLoader _fadeSceneLoader = default;

    [Inject]
    private readonly AudioManager _audioManager = default;

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

    [SerializeField]
    private UnitStorageView _unitStorageView = default;

    private void Awake()
    {
        InitializeStateMachine();
    }

    private void Start()
    {
        GoToState(GameState.FadeOut);
    }

    private void InitializeStateMachine()
    {
        //FadeOut
        {
            var state = new State<GameState>(GameState.FadeOut);
            state.UpdateAction = OnUpdateFadeOut;
            AddState(state);
        }
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

    #region FadeOutMethod

    private void OnUpdateFadeOut()
    {
        if (_fadeSceneLoader.IsFadeOutCompleted)
        {
            GoToState(GameState.Setting);
        }
    }
    #endregion

    #region SettingMethod
    private void OnSetUpSetting()
    {
        _audioManager.PlayBGM(BGMType.GameBGM);
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
        _playerController.InitializePlayer();

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
        _unitStorageView.ActiveUnitStorageView(false);

        _gameEndPresenter.OnResult();
    }
    private void OnUpdateFinish()
    {
        //Debug.Log("Finish");
    }

    #endregion
}
