using System.Collections;
using UnityEngine;

public class StartPresenter : MonoBehaviour
{
    [SerializeField]
    private StartViewer _startViewer = default;

    private bool isCompleteStartView = false;

    public IEnumerator OnGameStart()
    {
        _startViewer.ViewStart();

        yield return new WaitForSeconds(0.5f);

        isCompleteStartView = true;
    }

    public bool IsCompleteSetting()
    {
        return isCompleteStartView;
    }
}
