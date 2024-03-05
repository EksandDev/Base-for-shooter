using System;

public class EventBus
{
    public event Action EnemyDied;
    public event Action<int, int> AmmoChanged;
    public event Action WeaponChanged;
    public event Action<int, int> PlayerHealthChanged;
    public event Action<int> PlayerDamaging;
    public event Action PlayerDied;

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

    public void OnPlayerHealthChanged(int health, int maxHealth)
    {
        PlayerHealthChanged?.Invoke(health, maxHealth);
    }

    public void OnPlayerDamaging(int damage)
    {
        PlayerDamaging?.Invoke(damage);
    }

    public void OnPlayerDied()
    {
        PlayerDied?.Invoke();
    }
}
