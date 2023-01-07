using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    
    private EntityHealth _playerHealth;

    int CachedMaxHealth { get; set; }

    private void Start()
    {
        _playerHealth = _target.GetComponent<EntityHealth>();
        CachedMaxHealth = _playerHealth.CurrentHealth;
        _slider.maxValue = CachedMaxHealth;
        _slider.value = CachedMaxHealth;
        _text.text = $"{CachedMaxHealth} / {CachedMaxHealth}";
    }

    void Update()
    {
        if (_playerHealth.IsDead) {
            _slider.value = 0;
            _text.text = "0 / 0";
        } else {
            CachedMaxHealth = _playerHealth.MaxHealth;
            UpdateSlider(_playerHealth.CurrentHealth);
        }
    }

    void UpdateSlider(int newHealthValue)
    {
        _slider.value = (newHealthValue * 100) / CachedMaxHealth;
        _text.text = $"{newHealthValue} / {CachedMaxHealth}";
    }
}
