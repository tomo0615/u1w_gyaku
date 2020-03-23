using UnityEngine.UI;
using UnityEngine;

public class GameClearView : MonoBehaviour
{
    [SerializeField]
    private Text gameClearText = default;

    private void Start()
    {
        gameClearText.enabled = false;
    }
    public void ViewGameClear()
    {
        gameClearText.enabled = true;
    }
}
