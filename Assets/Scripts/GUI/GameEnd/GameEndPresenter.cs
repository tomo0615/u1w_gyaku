using UnityEngine;

public class GameEndPresenter : MonoBehaviour
{
    [SerializeField]
    private GameClearViewer _gameClearViewer = default;

    [SerializeField]
    private GameOverViewer _gameOverViewer = default;

    public bool IsGameEnd { private set; get; } = false;

    private void Awake()
    {
        _gameClearViewer.InitializeGameEndViewer();
        _gameOverViewer.InitializeGameEndViewer();
    }

    public void OnGameEnd(bool isClear)
    {
        IsGameEnd = true;

        if (isClear)
        {
            _gameClearViewer.ViewGameClear();
            return;
        }

        _gameOverViewer.ViewGameOver();
    }

}
