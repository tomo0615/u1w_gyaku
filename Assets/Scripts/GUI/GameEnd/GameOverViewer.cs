using UnityEngine;
using TMPro;
public class GameOverViewer : MonoBehaviour, IGameEndViewer
{
    private TextMeshProUGUI gameOverText;

    public void InitializeGameEndViewer()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
    }

    public void ViewGameOver()
    {
        gameOverText.enabled = true;
    }
}
