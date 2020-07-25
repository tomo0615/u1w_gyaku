using UnityEngine;
using TMPro;
public class GameOverViewer : MonoBehaviour, IGameEndViewer
{
    private TextMeshProUGUI gameOverText;

    public void InitializeGameEndViewer()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
    }

    // ActivateClearView(bool) 的な関数にしたい
    public void ViewGameOver()
    {
        gameOverText.enabled = true;
    }
}
