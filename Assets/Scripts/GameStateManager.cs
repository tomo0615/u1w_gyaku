using UnityEngine;

public class GameStateManager : StateMachine<GameState>
{
    /*Onhogeで参照する何かを書く
    [SerializeField]
    private 
    */
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
        //Animationを表示する
        //Debug.Log("Setting");
    }

    private void OnUpdateSetting()
    {
        //if(IsComplete()
        GoToState(GameState.Game);

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

    //Setting
    //Loading ->Stageの情報を表示,Unit数を表示-＞Startを表示
    //上記のUIを別で書く
    //Game
    //Playerの操作可能（それ以外のStateでは不可能）
    //
    //Finish
    //Resultー＞戻るなどのボタンなどの表示

    //GameEndは実装済み

}
