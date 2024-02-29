using TMPro;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammoText;

    private void OnAmmoChanged(int ammo, int maxAmmo)
    {
        _ammoText.text = ammo + " / " + maxAmmo;
    }

    private void OnEnable()
    {
        EventBus.Instance().AmmoChanged += OnAmmoChanged;
    }

    private void OnDisable()
    {
        EventBus.Instance().AmmoChanged -= OnAmmoChanged;
    }
}
