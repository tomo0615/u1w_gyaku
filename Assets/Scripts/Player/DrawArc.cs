using UnityEngine;

public class DrawArc : MonoBehaviour
{
    private LineRenderer[] _lineRenderers;

    [SerializeField]
    private Material _lineMaterial = default;

    [SerializeField]
    private int _lineCount = 60;

    [SerializeField]
    private float _lineWidth = 1;

    [SerializeField]
    private float _lineHight = 2f;

    private Vector3 _startVector = Vector3.zero;

    private void Start()
    {
        CreateLineRendererObjects();
    }

    public void DrawLine(Vector3 start, Vector3 end)
    {
        Vector3 lineVector = end - start;
        _startVector = start;

        lineVector /= _lineCount;//放物線の細かさを決定

        for(int i = 0; i < _lineCount; i++)
        {
            var nextVector = _startVector + lineVector;

            SetLineRendererPosition(i, _startVector, nextVector);

            _startVector = nextVector; 
        }
    }

    private void SetLineRendererPosition(int index, Vector3 start, Vector3 end)
    {
        start = new Vector3(start.x, start.y * _lineHight * index, start.z);
        end = new Vector3(end.x, end.y * _lineHight * index, end.z);

        _lineRenderers[index].SetPosition(0, start);
        _lineRenderers[index].SetPosition(1, end);
        _lineRenderers[index].enabled = true;
    }

    private void CreateLineRendererObjects()
    {
        // 親オブジェクトを作り、LineRendererを持つ子オブジェクトを作る
        GameObject arcObjectsParent = new GameObject("ArcObject");

        _lineRenderers = new LineRenderer[_lineCount];
        for (int i = 0; i < _lineCount; i++)
        {
            GameObject newObject = new GameObject("LineRenderer_" + i);
            newObject.transform.SetParent(arcObjectsParent.transform);
            _lineRenderers[i] = newObject.AddComponent<LineRenderer>();

            // 光源関連を使用しない
            _lineRenderers[i].receiveShadows = false;
            _lineRenderers[i].reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
            _lineRenderers[i].lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
            _lineRenderers[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            // 線の幅とマテリアル
            _lineRenderers[i].material = _lineMaterial;
            _lineRenderers[i].startWidth = _lineWidth;
            _lineRenderers[i].endWidth = _lineWidth;
            _lineRenderers[i].numCapVertices = 5;
            _lineRenderers[i].enabled = false;
        }
    }
}
