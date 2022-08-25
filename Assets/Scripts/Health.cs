using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event UnityAction HealthChanged;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        CurrentHealth = _maxHealth;
        HealthChanged?.Invoke();
    }

    public void Heal(float heal)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + heal, 0f, _maxHealth);
        HealthChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0f, _maxHealth);
        HealthChanged?.Invoke();
    }
}
