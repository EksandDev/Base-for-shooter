using TMPro;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammoText;
    [SerializeField] private TMP_Text _healthText;

    private void OnAmmoChanged(int ammo, int maxAmmo)
    {
        _ammoText.text = ammo + " / " + maxAmmo;
    }

    private void OnPlayerHealthChanged(int health, int maxHealth)
    {
        _healthText.text = health + " / " + maxHealth;
    }

    private void OnEnable()
    {
        EventBus.Instance().AmmoChanged += OnAmmoChanged;
        EventBus.Instance().PlayerHealthChanged += OnPlayerHealthChanged;
    }

    private void OnDisable()
    {
        EventBus.Instance().AmmoChanged -= OnAmmoChanged;
        EventBus.Instance().PlayerHealthChanged -= OnPlayerHealthChanged;
    }
}
