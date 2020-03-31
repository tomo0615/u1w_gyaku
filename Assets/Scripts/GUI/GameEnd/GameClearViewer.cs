using UnityEngine;
using TMPro;

public class GameClearViewer : MonoBehaviour, IGameEndViewer
{
    private TextMeshProUGUI gameClearText;

    public void InitializeGameEndViewer()
    {
        gameClearText = GetComponent<TextMeshProUGUI>();
    }

    public void ViewGameClear()
    {
        gameClearText.enabled = true;
    }
}
