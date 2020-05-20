using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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

    private Coroutine displayCoroutine = null;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetMaxHPValue(int hpValue)
    {
        slider.maxValue = hpValue;
        slider.value = hpValue;
    }
    private IEnumerator HideHpbar()
    {
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
    }

    public void OnHPValueChange(int hpValue)
    {
        gameObject.SetActive(true);

        if (displayCoroutine != null) StopCoroutine(displayCoroutine);
        displayCoroutine = StartCoroutine(HideHpbar());

        slider.value = hpValue;

        ChangeHPBarColor();
    }

    private void ChangeHPBarColor()
    {
        //徐々にMAXからminに色を変更していく
        float lerpValue = slider.value / slider.maxValue;

        var changedColor = Color.Lerp(minimumColor, maxColor, lerpValue);

        barFillImage.color = changedColor;
    }
}
