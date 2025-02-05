using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    [SerializeField] private Image _fillImage;

    [SerializeField] private  TMP_Text _text;

    public void setInitialHealth(int maxHealth)
    {
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;
    }

    public void updateHealth(int health)
    {
        _healthBar.value = health;
        updateText(health);
    }

    private void updateText(int health)
    {
        string newHealth = health + "/" + _healthBar.maxValue;
        _text.text = newHealth;
    }
}
