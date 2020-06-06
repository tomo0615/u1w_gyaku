using System;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Unit.SummonEffect
{
    public class SummonObject : MonoBehaviour
    {
        [SerializeField]
        private double _animationTime = 10;

        public IObservable<UniRx.Unit> PlayEffect(Vector3 position)
        {
            transform.position = position;

            DoStartAnimation();

            return Observable
                .Timer(TimeSpan.FromSeconds(_animationTime))
                .ForEachAsync(_ => DoFinishAnimation());
        }

        private void DoStartAnimation()
        {
            transform.position -= Vector3.one;

            transform.DOMoveY(transform.position.y + 1, 0.25f);
        }

        private void DoFinishAnimation()
        {
            transform.DOMoveY(transform.position.y - 1, 0.25f);
        }
    }
}
