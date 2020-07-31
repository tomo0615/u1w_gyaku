using UnityEngine;

public class PlayerRayCaster
{
    private readonly Camera _camera;

    private readonly Transform _transform;

    private static readonly int HitableLayer = 1 << LayerMask.NameToLayer("Building");

    public PlayerRayCaster(Camera camera, Transform transform)
    {
        _camera = camera;
        _transform = transform;
    }

    //Rayの当たった場所を取得
    public Vector3 GetPositionByRay(Vector3 mousePosition)
    {
        var ray = _camera.ScreenPointToRay(mousePosition);

        if (!Physics.Raycast(ray, out var hit)) return _transform.position; //Plane外をクリックしても変化がないように
        
        var lookPoint = hit.point;
        lookPoint.y = _transform.position.y;

        //Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
        return lookPoint;
    }

    public Transform GetRayHitObject(Vector3 mousePosition)
    {
        var ray = _camera.ScreenPointToRay(mousePosition);
        
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, HitableLayer))
        {
            return hit.transform;
        }

        return null;
    }
}
