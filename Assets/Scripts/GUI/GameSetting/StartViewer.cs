using UnityEngine;

public class StartViewer : MonoBehaviour
{
    [SerializeField]
    private Animator _animator = default;

    public void ViewStart()
    {
        _animator.Play("StartUIAnimation");
    }
}
