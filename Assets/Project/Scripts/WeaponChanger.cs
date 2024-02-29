using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;

    private void Update()
    {
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckWeapons(0);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckWeapons(1);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckWeapons(2);
        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CheckWeapons(3);
        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CheckWeapons(4);
        }
    }

    private void CheckWeapons(int index)
    {
        EventBus.Instance().OnWeaponChanged();

        if (_weapons[index].TryGetComponent<GunsBase>(out GunsBase gun))
        {
            int ammo = gun.Ammo;
            int maxAmmo = gun.MaxAmmo;
            EventBus.Instance().OnAmmoChanged(ammo, maxAmmo);

            foreach (var weapon in _weapons)
            {
                weapon.SetActive(false);
            }

            _weapons[index].SetActive(true);
        }
    }
}
