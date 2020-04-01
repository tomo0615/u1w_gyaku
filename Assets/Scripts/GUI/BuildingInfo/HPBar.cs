using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class HPBar : MonoBehaviour
{
    private Slider slider;
    private Slider Slider => slider
        = slider ?? GetComponent<Slider>(); //Editor状態でテストするため

    [SerializeField]
    private Image barFillImage = default;

    [SerializeField]
    private Color maxColor = Color.green;

    [SerializeField]
    private Color minimumColor = Color.red;

    public void ChangeColor()
    {
        //徐々にMAXからminに色を変更していく
        float lerpValue = Slider.value / Slider.maxValue;

        barFillImage.color = Color.Lerp(minimumColor,　maxColor, lerpValue);
    }
}
