using UnityEngine;
using TMPro;
public class GameOverView : MonoBehaviour
{
    private TextMeshProUGUI gameOverText;

    public void InitializeGameEndView()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
        //gameOverText.enabled = false;
    }

    public void ViewGameOver()
    {
        gameOverText.enabled = true;
    }
}
