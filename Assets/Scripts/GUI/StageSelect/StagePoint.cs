using UnityEngine;
using Zenject;

public class StagePoint : MonoBehaviour , IStagePoint
{
    [SerializeField]
    private SceneName _stageName = SceneName.Stage1;

    [Inject]
    private readonly FadeSceneLoader _fadeSceneLoader = default;


    public void StageSelected()
    {
        Debug.Log("hit");
        //_fadeSceneLoader.JumpSceneLoad(_stageName);
    }
}
