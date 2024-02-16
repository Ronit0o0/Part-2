using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        SendMessage("SetHealth");
    }
    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }

    void SetHealth()
    {
        slider.value = PlayerPrefs.GetFloat("healthBar", 5);
    }
}
