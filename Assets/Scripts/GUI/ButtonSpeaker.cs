using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
using Zenject;

[RequireComponent(typeof(Button))]
public class ButtonSpeaker : MonoBehaviour
{
    [Inject] private AudioManager _audioManager = default;
    [SerializeField] private SEType _clickedSeType;

    private void Awake()
    {
        var listenerButton = GetComponent<Button>();
        listenerButton
            .OnClickAsObservable()
            .Subscribe(_ =>
            {
                _audioManager.PlaySE(_clickedSeType);
            })
            .AddTo(gameObject);
    }
}
