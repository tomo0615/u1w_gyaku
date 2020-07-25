using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TitleSequencer : MonoBehaviour
{ 
    [Inject] private FadeSceneLoader.FadeSceneLoader _fadeSceneLoader = default;
    [SerializeField] private Button gameStartButton;
    [SerializeField] private SceneName _jumpSceneName = default;

    private void Awake()
    {
        gameStartButton
            .OnClickAsObservable()
            .Subscribe((_) =>
            {
                _fadeSceneLoader.JumpSceneLoad(_jumpSceneName);
            })
            .AddTo(gameObject);
    }
}
