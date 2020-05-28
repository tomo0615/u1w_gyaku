using UnityEngine;
using DG.Tweening;

public class PlayerPointer : MonoBehaviour
{
    [SerializeField]
    private GameObject _pointerObject = default;

    [SerializeField]
    private Transform _spriteTransform = default;

    [SerializeField]
    private float _animationTime = 1.2f;

    public void Initialize()
    {
        _pointerObject.SetActive(true);

        DoPointerAnimation();
    }

    private void DoPointerAnimation()
    {
        _spriteTransform.DOScale(Vector3.one / 1.5f, _animationTime / 2)
            .OnComplete(() =>
            {
                transform.DOScale(Vector3.one * 1.5f, _animationTime);
            })
            .SetLoops(-1, LoopType.Yoyo);
    }
}
