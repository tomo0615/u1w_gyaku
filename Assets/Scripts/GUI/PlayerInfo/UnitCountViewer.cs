using TMPro;
using UnityEngine;

public class UnitCountViewer : MonoBehaviour
{
    private TextMeshProUGUI unitCountText;

    public void InitializeUnitCountViewer()
    {
        unitCountText = GetComponent<TextMeshProUGUI>();
    }

    public void ViewUnitCount(int unitCount)
    {
        unitCountText.text = unitCount.ToString();
    }
}
