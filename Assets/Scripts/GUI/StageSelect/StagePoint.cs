using UnityEngine;
using Zenject;
using DG.Tweening;

public class StagePoint : MonoBehaviour
{
    [SerializeField]
    private SceneName _stageName = SceneName.Stage1;

    [Inject]
    private readonly FadeSceneLoader _fadeSceneLoader = default;

    private void Start()
    {
        transform.DOShakeRotation(5, 8, 0).SetLoops(-1);
    }

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
