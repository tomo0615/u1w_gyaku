using System.Collections;
using UnityEngine;

public class StartPresenter : MonoBehaviour
{
    [SerializeField]
    private StartViewer _startViewer = default;

    public void OnGameStart()
    {
        _startViewer.ViewStart();
    }
}
