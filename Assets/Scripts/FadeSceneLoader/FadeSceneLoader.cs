using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace FadeSceneLoader
{
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

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
        {
            DoFadeOut();
        }
        public void CurrentSceneLoad()
        {
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            var sceneName = ((SceneName)currentScene).ToString();

            DoFadeInSceneLoad(sceneName);
        }

        public void JumpSceneLoad(SceneName sceneName)
        {
            var scene = sceneName.ToString();

            DoFadeInSceneLoad(scene);
        }

        public void NextSceneLoad()
        {
            var currentSceneName = SceneManager.GetActiveScene().buildIndex;

            // 定数化したい
            var enumMax = Enum.GetValues(typeof(SceneName)).Length;
            var nextIndex = (int)(currentSceneName + 1) % enumMax;

            var nextSceneName = (SceneName)nextIndex;
            var scene = nextSceneName.ToString();

            DoFadeInSceneLoad(scene);
        }

        private void DoFadeInSceneLoad(string sceneName)
        {
            _fade.FadeIn(fadeTime, () =>
            {
                _zenjectSceneLoader.LoadScene(sceneName);
            });
        }

        // private
        public void DoFadeOut()
        {
            IsFadeOutCompleted = false;

            _nowLoadingView.DOAnimation(fadeInterval, () =>
            {
                // 関数化した方が可読性高
                _fade.FadeOut(fadeTime, () =>
                {
                    IsFadeOutCompleted = true;
                });
            });
        }
    }
}
