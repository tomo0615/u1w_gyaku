using UnityEngine;
using DG.Tweening;

public class PlayerPointer : MonoBehaviour
{
    [SerializeField]
    private Transform _spriteTransform = default;

    public void Initialize()
    {
        DoPointerAnimation();
    }

    private void DoPointerAnimation()
    {
        _spriteTransform.DOScale(Vector3.one / 1.5f, 1.2f)
            .OnComplete(() =>
            {
                transform.DOScale(Vector3.one * 1.5f, 1.2f);
            })
            .SetLoops(-1,LoopType.Yoyo);
    }
}
