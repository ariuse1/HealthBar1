using UnityEngine;
using UnityEngine.Events;

public class Heallth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _lastHealth;
    [SerializeField] private Bar _healthBar;

    private UnityEvent _die = new UnityEvent();

    private float _minHealth;

    public event UnityAction Die
    {
        add => _die.AddListener(value);
        remove => _die.RemoveListener(value);
    }

    private void Start()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

        if (_healthBar != null)
            _healthBar.SetStartParameters(_maxHealth, _currentHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);
        _healthBar.SetHealth(_currentHealth);

        if (_currentHealth == _minHealth)
            _die.Invoke();
    }

    public void TakeHealth(float health)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + health, _minHealth, _maxHealth);
        _healthBar.SetHealth(_currentHealth);
    }
}
