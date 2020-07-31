using UnityEngine;
using Zenject;

namespace GUI.Title
{
    public class LoadButton : BaseButton
    {
        [Inject]
        private FadeSceneLoader.FadeSceneLoader _fadeSceneLoader = default;

        [SerializeField]
        private SceneName jumpSceneName = default;

        public override void OnClicked()
        {
            base.OnClicked();

            _fadeSceneLoader.JumpSceneLoad(jumpSceneName);
        }
    }
}
