using UnityEngine.UI;
using UnityEngine;

public class GameOverView : MonoBehaviour
{
    [SerializeField]
    private Text gameOverText = default;

    private void Start()
    {
        gameOverText.enabled = false;
    }
    public void ViewGameOver()
    {
        gameOverText.enabled = true;
    }
}
