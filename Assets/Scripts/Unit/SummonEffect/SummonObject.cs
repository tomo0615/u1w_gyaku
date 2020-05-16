using System;
using UniRx;
using DG.Tweening;
using UnityEngine;

public class SummonObject : MonoBehaviour
{
    [SerializeField]
    private double _animationTime = 10;

    public IObservable<Unit> PlayEffect(Vector3 position)
    {
        transform.position = position;

        DoStartAnimation();

        return Observable
            .Timer(TimeSpan.FromSeconds(_animationTime))
            .ForEachAsync(_ => DoFinishAnimation());
    }

    private void DoStartAnimation()
    {
        var position = transform.position;

        transform.position -= Vector3.one;

        transform.DOMoveY(transform.position.y + 1, 0.25f);
    }

    private void DoFinishAnimation()
    {
        transform.DOMoveY(transform.position.y - 1, 0.25f);
    }
}
