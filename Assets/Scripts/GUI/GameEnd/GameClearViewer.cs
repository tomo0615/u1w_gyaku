using UnityEngine;
using TMPro;

public class GameClearViewer : MonoBehaviour, IGameEndViewer
{
    private TextMeshProUGUI gameClearText;

    public void InitializeGameEndViewer()
    {
        gameClearText = GetComponent<TextMeshProUGUI>();
    }

    // ActivateClearView(bool) 的な関数にしたい
    public void ViewGameClear()
    {
        gameClearText.enabled = true;
    }
}
