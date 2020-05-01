using UnityEngine;
using Zenject;

public class StagePoint : MonoBehaviour
{
    [SerializeField]
    private SceneName _stageName = SceneName.Stage1;

    [Inject]
    private readonly FadeSceneLoader _fadeSceneLoader = default;

    private void OnMouseEnter()
    {
        MouseEnterAnimation();
    }

    private void OnMouseUpAsButton()
    {
        StageSelected();
    }

    private void MouseEnterAnimation()
    {

    }

    private void StageSelected()
    {
        _fadeSceneLoader.JumpSceneLoad(_stageName);
    }
}
