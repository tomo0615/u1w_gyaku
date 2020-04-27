using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using System;

public class FadeSceneLoader : MonoBehaviour
{
    [SerializeField]
    private Fade _fade = default;

    [SerializeField]
    private NowLoadingView _nowLoadingView = default;

    [SerializeField]
    private float fadeTime = 1f;

    [SerializeField]
    private float fadeInterval = 1f;

    public bool IsFadeOutCompleted { get; private set; }
        = false;

    private ZenjectSceneLoader _zenjectSceneLoader;

    [Inject]
    private void Construct(ZenjectSceneLoader zenjectSceneLoader)
    {
        _zenjectSceneLoader = zenjectSceneLoader;
    }

    public void JumpSceneLoad(SceneName sceneName)
    {
        var scene = sceneName.ToString();

        DOFadeInSceneLoad(scene);
    }
    public void NextSceneLoad()
    {
        var _currentSceneName = SceneManager.GetActiveScene().buildIndex;

        var enumMax = Enum.GetValues(typeof(SceneName)).Length;
        var nextIndex = (int)(_currentSceneName + 1) % enumMax;

        var nextSceneName = (SceneName)nextIndex;
        var scene = nextSceneName.ToString();

        DOFadeInSceneLoad(scene);
    }

    private void DOFadeInSceneLoad(string sceneName)
    {
        _fade.FadeIn(fadeTime, () =>
        {
            _zenjectSceneLoader.LoadScene(sceneName);
        });
    }

    public void DoFadeOut()
    {
        IsFadeOutCompleted = false;

        _nowLoadingView.DOAnimation(fadeInterval, () =>
        {
            _fade.FadeOut(fadeTime, () =>
            {
                IsFadeOutCompleted = true;
            });
        });
    }
}
