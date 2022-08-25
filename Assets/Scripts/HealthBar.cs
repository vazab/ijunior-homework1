using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private float _lastCurrentHealth;
    private float _changingRate = 1f;
    private Coroutine _changeHealthJob;
    private Slider _slider;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
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
        float normalizeHealth = _health.CurrentHealth / _health.MaxHealth;

        while (_slider.value != normalizeHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, normalizeHealth, _changingRate * Time.deltaTime);
            yield return null;
        }
    }
}
