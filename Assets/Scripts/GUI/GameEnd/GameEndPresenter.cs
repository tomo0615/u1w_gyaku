using UnityEngine;

public class GameEndPresenter : MonoBehaviour
{
    [SerializeField]
    private GameClearViewer _gameClearViewer = default;

    [SerializeField]
    private GameOverViewer _gameOverViewer = default;

    [SerializeField]
    private ResultButton _resultButton = default;

    public bool IsGameEnd { private set; get; } = false;

    private void Awake()
    {
        _gameClearViewer.InitializeGameEndViewer();

        _gameOverViewer.InitializeGameEndViewer();

        _resultButton.InitializeResultButton();
    }

    public void OnGameEnd(bool isClear)
    {
        IsGameEnd = true;

        if (isClear)
        {
            _gameClearViewer.ViewGameClear();
        }
        else
        {
            _gameOverViewer.ViewGameOver();
        }

        //resultButtonを表示
        _resultButton.SetActiveButton();
    }

}
