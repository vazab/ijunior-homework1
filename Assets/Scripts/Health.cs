using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _heal;
    [SerializeField] private float _damage;
    
    public UnityAction HealthChanged;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => _maxHealth;

    public void Heal()
    {
        bool isOverHeal = _maxHealth - CurrentHealth < _heal;
        if (isOverHeal)
        {
            CurrentHealth = _maxHealth;
        }
        else
        {
            CurrentHealth += _heal;
        }

        HealthChanged?.Invoke();
    }

    public void TakeDamage()
    {
        bool isOverDamage = _damage > CurrentHealth;
        if (isOverDamage)
        {
            CurrentHealth = 0f;
        }
        else
        {
            CurrentHealth -= _damage;
        }
        
        HealthChanged?.Invoke();
    }

    private void Start()
    {
        CurrentHealth = _maxHealth;
        HealthChanged?.Invoke();
    }
}
