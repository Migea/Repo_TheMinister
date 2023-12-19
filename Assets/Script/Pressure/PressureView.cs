using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressureView : MonoBehaviour
{
    public Image fillImage;
    public RectTransform textWrapper;
    public Text PercentageText;
    public Text AddPerDayText;
    
    public void SetPercentage(int percentage)
    {
        fillImage.fillAmount = percentage / 100f;
        PercentageText.text = $"{percentage}%";
        ForceLayout();
    }
    public void SetAddPerDay(int amount)
    {
        int add = PressureManager.Instance.pressureAddPerDay;
        AddPerDayText.text = $"{amount}����\r\n{add}��";
        ForceLayout();
    }
    public void FixedUpdate()
    {
        ForceLayout();
    }
    private void ForceLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(textWrapper);
    }
}
