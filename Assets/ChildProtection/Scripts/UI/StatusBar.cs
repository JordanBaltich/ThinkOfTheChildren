using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Image currentFillBar, improvementFillBar;

    public float currentFillAmount, improvementFillAmount;

    private void Start()
    {
        improvementFillAmount = currentFillAmount;
        UpdateBars();
    }

    public void FillBar(float amount)
    {
        currentFillAmount += amount;
        improvementFillAmount = currentFillAmount;
        UpdateBars();
    }

    public void DrainBar(float amount)
    {
        currentFillAmount -= amount;
        improvementFillAmount = currentFillAmount;
        UpdateBars();

    }

    public void ShowImprovement(float amount)
    {
        improvementFillAmount += amount;
        UpdateBars();
    }

    public void HideImprovement()
    {
        improvementFillAmount = currentFillAmount;
        UpdateBars();
    }

    void UpdateBars()
    {
        currentFillBar.fillAmount = currentFillAmount;
        improvementFillBar.fillAmount = improvementFillAmount;
    }
}
