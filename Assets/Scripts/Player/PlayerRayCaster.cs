using UnityEngine;

public class PlayerRayCaster
{
    private readonly Camera _camera;

    private readonly Transform _transform;

    public PlayerRayCaster(Camera camera, Transform transform)
    {
        _camera = camera;
        _transform = transform;
    }

    //Rayの当たった場所を取得
    public Vector3 GetPositionByRay(Vector3 mousePosition)
    {
        Ray ray = _camera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var lookPoint = hit.point;
            lookPoint.y = _transform.position.y;

            //Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            return lookPoint;
        }

        return _transform.position;//Plane外をクリックしても変化がないように
    }

    public Transform GetRayHitObject(Vector3 mousePosition)
    {
        Ray ray = _camera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        int layerMask = 1 << LayerMask.NameToLayer("Building"); 
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            return hit.transform;
        }

        return null;
    }
}
