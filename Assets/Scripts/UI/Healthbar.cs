using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider healthbarSlider;
    private Quaternion startRotation;

    private void Awake()
    {
        healthbarSlider = GetComponent<Slider>();
    }

    public void UpdateHealthbar(int maxHealth, int currentHealth)
    {
        healthbarSlider.maxValue = maxHealth;
        healthbarSlider.minValue = 0;
        healthbarSlider.value = currentHealth;
    }
}
