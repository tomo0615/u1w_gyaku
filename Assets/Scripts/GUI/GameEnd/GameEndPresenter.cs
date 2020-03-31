using UnityEngine;

public class GameEndPresenter : MonoBehaviour
{
    [SerializeField]
    private GameClearViewer _gameClearViewer = default;

    [SerializeField]
    private GameOverViewer _gameOverViewer = default;

    private void Awake()
    {
        _gameClearViewer.InitializeGameEndViewer();
        _gameOverViewer.InitializeGameEndViewer();
    }

    public void OnGameEnd(bool isClear)
    {
        if (isClear)
        {
            _gameClearViewer.ViewGameClear();
            return;
        }

        _gameOverViewer.ViewGameOver();
    }

}
