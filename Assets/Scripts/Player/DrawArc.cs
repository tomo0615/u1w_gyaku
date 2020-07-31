using UnityEngine;

public class DrawArc : MonoBehaviour
{
    private LineRenderer[] _lineRenderers;

    [SerializeField] private GameObject arcLine;
    
    [SerializeField]
    private Material lineMaterial = default;

     [SerializeField]
    private int lineCount = 60;
    
    [SerializeField]
    private float lineWidth = 1;

    [SerializeField]
    private float lineHight = 0.15f;

    private Vector3 _startVector = Vector3.zero;

    private void Start()
    {
        CreateLineRendererObjects();
    }

    public void DrawLine(Vector3 start, Vector3 end)
    {
        Vector3 lineVector = end - start;
        _startVector = start;

        lineVector /= lineCount;//放物線の細かさを決定

        for(int i = 0; i < lineCount; i++)
        {
            var nextVector = _startVector + lineVector;

            SetLineRendererPosition(i, _startVector, nextVector);

            _startVector = nextVector; 
        }
    }

    private void SetLineRendererPosition(int index, Vector3 start, Vector3 end)
    {
        start = new Vector3(start.x, start.y * lineHight * index, start.z);
        end = new Vector3(end.x, end.y * lineHight * index, end.z);

        _lineRenderers[index].SetPosition(0, start);
        _lineRenderers[index].SetPosition(1, end);
        _lineRenderers[index].enabled = true;
    }

    private void CreateLineRendererObjects()
    {
        // 親オブジェクトを作り、LineRendererを持つ子オブジェクトを作る
        var arcObjectsParent = new GameObject("ArcObject");

        _lineRenderers = new LineRenderer[lineCount];
        for (var i = 0; i < lineCount; i++)
        {
            var line = Instantiate(arcLine, transform.position, Quaternion.identity);
            line.transform.parent = arcObjectsParent.transform;
            
            _lineRenderers[i] = line.GetComponent<LineRenderer>();
            
            InitializeLineRenderer(_lineRenderers[i]);
        }
    }
    
    private void InitializeLineRenderer(LineRenderer lineRenderer)
    {
        // 光源関連を使用しない
        lineRenderer.receiveShadows = false;
        lineRenderer.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
        lineRenderer.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        // 線の幅とマテリアル
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.numCapVertices = 5;
        lineRenderer.enabled = false;
    }
}
