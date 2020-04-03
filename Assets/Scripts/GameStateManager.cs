using UnityEngine;

public class GameStateManager :StateMachine<GameState>
{
    [SerializeField]
    private GameState currentGameState = GameState.Setting;

    private void Awake()
    {
        InitializeStateMachine();
    }

    private void Start()
    {
        
    }

    private void InitializeStateMachine()
    {

    }
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
