using UnityEngine;

public class GameEndPresenter : MonoBehaviour
{
    [SerializeField]
    private GameClearView _gameClearView = default;

    [SerializeField]
    private GameOverView _gameOverView = default;

    private void Awake()
    {
        _gameClearView.InitializeGameEndView();
        _gameOverView.InitializeGameEndView();
    }

    public void OnGameEnd(bool isClear)
    {
        if (isClear)
        {
            _gameClearView.ViewGameClear();
            return;
        }

        _gameOverView.ViewGameOver();
    }

}
