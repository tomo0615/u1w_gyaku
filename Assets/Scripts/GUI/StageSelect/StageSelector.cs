using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;

public class StageSelector : MonoBehaviour
{
    private Camera _camera;

    private IStagePoint stagePoint;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => GetRayHitStagePoint(Input.mousePosition))
            .AddTo(this);

        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonUp(0))
            .Subscribe(_ => stagePoint.StageSelected())
            .AddTo(this);
    }

    public void GetRayHitStagePoint(Vector3 mousePosition)
    {
        Ray ray = _camera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("StagePoint");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            stagePoint = hit.transform.gameObject.GetComponent<IStagePoint>();
        }
        else
        {
            stagePoint = null;
        }
    }
}
