using System;
using DG.Tweening;
using UnityEngine;
using Zenject;
using FadeSceneLoader;

namespace GUI.GameEnd
{
    public class ResultButton : MonoBehaviour
    {
        [Inject]
        private readonly FadeSceneLoader.FadeSceneLoader _fadeSceneLoader = default;

        private RectTransform _rectTransform;

        public Action OnClickedResultButtonListner = default;

        public void InitializeResultButton()
        {
            _rectTransform = GetComponent<RectTransform>();

            gameObject.SetActive(false);
        }

        // マジックナンバーは定数化したい
        public void SetActiveButton()
        {
            var localScale = _rectTransform.localScale;
            localScale /= 10;
            _rectTransform.localScale = localScale;

            gameObject.SetActive(true);

            _rectTransform.DOScale(localScale * 10, 1f);

        }

        public void OnRetry()
        {
            OnClickedResultButtonListner.Invoke();

            _fadeSceneLoader.CurrentSceneLoad();
        }

        public void OnNextStage()
        {
            OnClickedResultButtonListner.Invoke();

            _fadeSceneLoader.NextSceneLoad();
        }

        public void OnReturnStageSelect()
        {
            OnClickedResultButtonListner.Invoke();

            _fadeSceneLoader.JumpSceneLoad(SceneName.StageSelect);
        }
    }
}
