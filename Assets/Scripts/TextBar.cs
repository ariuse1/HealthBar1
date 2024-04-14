using System;
using TMPro;
using UnityEngine;

public class TextBar : Bar
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private TextMeshProUGUI _maxHealthText;
    [SerializeField] private TextMeshProUGUI _currentHealthText;
    [SerializeField] private String _delimiter = "/";

    private void Start()
    {
        SetStartParameters(_maxHealth, _currentHealth);
    }

    public override void SetStartParameters(float maxHealth, float currentHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = currentHealth;
        _maxHealthText.SetText($"{_delimiter} {_maxHealth}");
        _currentHealthText.SetText($"{_maxHealth}");
        _currentHealthText.color = _gradient.Evaluate(_currentHealth / _maxHealth);
        _maxHealthText.color = _gradient.Evaluate(1f);
    }

    public override void SetMaxHealth(float maxHealth)
    {
        _maxHealth = maxHealth;   
        _maxHealthText.SetText($"{_delimiter} {_maxHealth}");
    }

    public override void SetHealth(float _currentHealth)
    {
        _currentHealthText.color = _gradient.Evaluate(_currentHealth / _maxHealth);
        _currentHealthText.SetText($"{_currentHealth}");
    }
}
