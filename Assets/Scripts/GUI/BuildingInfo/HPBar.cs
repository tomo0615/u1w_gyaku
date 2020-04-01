using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class HPBar : MonoBehaviour
{
    private Slider slider;

    [SerializeField]
    private Image barFillImage = default;

    [SerializeField]
    private Color maxColor = Color.green;

    [SerializeField]
    private Color minimumColor = Color.red;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHPValue(int hpValue)
    {
        slider.maxValue = hpValue;
        slider.value = hpValue;
    }

    public void OnHPValueChange(int hpValue)
    {
        slider.value = hpValue;

        //徐々にMAXからminに色を変更していく
        float lerpValue = slider.value / slider.maxValue;

        barFillImage.color = Color.Lerp(minimumColor,　maxColor, lerpValue);
    }
}
