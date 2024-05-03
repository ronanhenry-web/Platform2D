using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct ColorThreshold
{
    public Color Color;
    public float Threshold;
}

public class HealthBarBehaviour : MonoBehaviour
{
    public ColorThreshold[] Colors;
    public Image Image;

    [Header("For testing purposes only")]
    [Range(0, 100)]
    public int Percent;

    private void OnValidate()
    {
        SetHealth(Percent, 100);
    }

    public void SetHealth(int currentHealth, int maxHealth)
    {
        float ratio = currentHealth / (float)maxHealth;
        Image.fillAmount = ratio;

        Color color = Colors[0].Color;
        foreach (ColorThreshold threshold in Colors)
        {
            if (ratio > threshold.Threshold)
            {
                color = threshold.Color;
                break;
            }
        }

        Image.color = color;
    }
}
