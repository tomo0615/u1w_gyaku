using UnityEngine;
using DG.Tweening;
using TMPro;

public class StartViewer : MonoBehaviour
{
    [SerializeField]
    private Animator _animator = default;

    [SerializeField]
    private TextMeshProUGUI _stageNameText = default;

    private RectTransform _stageNameRect;

    private void Awake()
    {
        _stageNameRect = _stageNameText.GetComponent<RectTransform>();
    }

    public void ViewStart()
    {
        Sequence sequence = DOTween.Sequence()
            .OnStart(() =>
            {
                _stageNameText.text = "Stage1";//テスト用

                _stageNameRect.DOScale(Vector3.one, 0.5f);
            })
            .PrependCallback(() =>
            {
                _stageNameRect.DOScale(Vector3.zero, 0.1f)
                .OnComplete(() =>
                {
                    _stageNameText.text = "";//テスト用

                    _animator.Play("StartUIAnimation");
                });
            })
            .PrependInterval(1f);

        sequence.Play();
    }
}
