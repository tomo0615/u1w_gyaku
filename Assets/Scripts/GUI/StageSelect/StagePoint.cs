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
        //浮遊アニメーション
        transform.DOShakeRotation(5, 7, 0).SetLoops(-1);
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
        //Todo:何らかのAnimationを実装
    }

    private void StageSelected()
    {
        _fadeSceneLoader.JumpSceneLoad(_stageName);
    }
}
