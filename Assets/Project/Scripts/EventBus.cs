using System;

public class EventBus
{
    public event Action EnemyDied;
    public event Action<int, int> AmmoChanged;
    public event Action WeaponChanged;

    private static EventBus _instance;

    public static EventBus Instance()
    {
        if (_instance == null)
            _instance = new EventBus();

        return _instance;
    }

    public void OnEnemyDied()
    {
        EnemyDied?.Invoke();
    }

    public void OnAmmoChanged(int ammo, int maxAmmo)
    {
        AmmoChanged?.Invoke(ammo, maxAmmo);
    }

    public void OnWeaponChanged()
    {
        WeaponChanged?.Invoke();
    }
}
