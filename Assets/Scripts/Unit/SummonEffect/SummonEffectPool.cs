using UnityEngine;
using UniRx.Toolkit;
using Unit.SummonEffect;

public class SummonEffectPool : ObjectPool<SummonObject>
{
    private readonly SummonObject _object;

    private readonly Transform _transform;

    public SummonEffectPool(Transform transform, SummonObject gameObject)
    {
        _transform = transform;
        _object = gameObject;
    }

    protected override SummonObject CreateInstance()
    {
        var obj = GameObject.Instantiate(_object);

        obj.transform.SetParent(_transform);

        return obj;
    }
}
