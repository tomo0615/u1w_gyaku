using UnityEngine;
using TMPro;

public class GameClearView : MonoBehaviour
{
    private TextMeshProUGUI gameClearText;

    public void InitializeGameEndView()
    {
        gameClearText = GetComponent<TextMeshProUGUI>();
        //gameClearText.enabled = false;
    }

    public void ViewGameClear()
    {
        gameClearText.enabled = true;
    }
}
