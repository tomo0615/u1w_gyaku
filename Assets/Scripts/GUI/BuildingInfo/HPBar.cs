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

    // readonly の方が好き
    [SerializeField]
    private Color maxColor = Color.green;

    // readonly の方が好き
    [SerializeField]
    private Color minimumColor = Color.red;

    private Coroutine displayCoroutine = null;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        // ActivateHpBar(bool) 的な関数にしたい
        gameObject.SetActive(false);
    }

    // InitializeHpValue の方が好き
    public void SetMaxHPValue(int hpValue)
    {
        slider.maxValue = hpValue;
        slider.value = hpValue;
    }
    // HP か Hp は統一したい
    // Bar か bar は統一したい
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
