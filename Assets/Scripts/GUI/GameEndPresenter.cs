using UnityEngine;

public class GameEndPresenter : MonoBehaviour
{
    [SerializeField]
    private GameClearView _gameClearView = default;

    [SerializeField]
    private GameOverView _gameOverView = default;

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
