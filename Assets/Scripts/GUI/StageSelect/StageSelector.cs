using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class StageSelector : MonoBehaviour
{
    [SerializeField]
    private SceneName _stageName = SceneName.Stage1;

    [Inject]
    private FadeSceneLoader _fadeSceneLoader = default;


    private void Start()
    {

    }

    public void OnSelected()
    {
        _fadeSceneLoader.JumpSceneLoad(_stageName);
    }
}
