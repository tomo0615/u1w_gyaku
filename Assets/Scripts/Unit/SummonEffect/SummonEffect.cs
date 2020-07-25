﻿using UnityEngine;
using UniRx;
using Unit.SummonEffect;

public class SummonEffect : MonoBehaviour
{
    [SerializeField]
    private SummonObject effectPrefab = default;

    private Transform _transform;

    private SummonEffectPool _summonEffectPool;

    private void Start()
    {
        _transform = GetComponent<Transform>();

        InitializeSummonEffect();
    }

    public void InitializeSummonEffect()
    {
        _summonEffectPool = new SummonEffectPool(_transform, effectPrefab);
    }

    public void InstanceSummonEffect(Vector3 position)
    {
        // 命名変えた方が良い
        var gameObj = _summonEffectPool.Rent();

        gameObj.PlayEffect(position)
            .Subscribe(_ =>
            {
                _summonEffectPool.Return(gameObj);
            });
    }
}
