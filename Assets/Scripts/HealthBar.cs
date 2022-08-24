using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private float _lastCurrentHealth;
    private float _changingRate = 1f;
    private Coroutine _changeHealthJob;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        if (_changeHealthJob != null)
        {
            StopCoroutine(_changeHealthJob);
        }

        _changeHealthJob = StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        Slider slider = GetComponent<Slider>();
        float normalizeHealth = _health.CurrentHealth / _health.MaxHealth;

        while (slider.value != normalizeHealth)
        {
            slider.value = Mathf.MoveTowards(slider.value, normalizeHealth, _changingRate * Time.deltaTime);
            yield return null;
        }
    }
}
