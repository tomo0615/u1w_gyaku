using UnityEngine;

namespace GUI.GameEnd
{
    public class GameEndPresenter : MonoBehaviour
    {
        [SerializeField]
        private GameClearViewer _gameClearViewer = default;

        [SerializeField]
        private GameOverViewer _gameOverViewer = default;

        [SerializeField]
        private ResultButton _resultButton = default;

        [SerializeField]
        private GameEndView _gameEndView = default;

        public bool IsGameEnd { private set; get; } = false;

        private bool IsClear { set; get; } = false;

        private void Awake()
        {
            _gameClearViewer.InitializeGameEndViewer();

            _gameOverViewer.InitializeGameEndViewer();

            _resultButton.InitializeResultButton();

            _resultButton.OnClickedResultButtonListner = OnClickedResultButton;
        }
        private void Start()
        {
            _gameEndView.ActiveGameEndView(false);
        }

        public void OnGameEnd(bool isClear)
        {
            IsGameEnd = true;

            IsClear = isClear;
        }

        public void OnResult()
        {
            // _gameClearViewer と _gameOverViewer は _gameEndView にまとめられそう
            _gameEndView.ActiveGameEndView(true);


            if (IsClear)
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

        public void OnClickedResultButton()
        {
            _gameEndView.ActiveGameEndView(false);
        }
    }
}
