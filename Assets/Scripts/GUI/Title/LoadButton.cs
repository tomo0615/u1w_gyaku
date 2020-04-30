using UnityEngine;
using Zenject;
using UniRx;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    [Inject]
    private FadeSceneLoader _fadeSceneLoader = default;

    private Button _button;

    [SerializeField]
    private SceneName _jumpSceneName = default;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.OnClickAsObservable()
            .Subscribe(_ => OnClicked())
            .AddTo(this);
    }

    public void OnClicked()
    {
        _fadeSceneLoader.JumpSceneLoad(_jumpSceneName);
    }
}
