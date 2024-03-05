using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health
    {
        get => _health;
        set 
        { 
            _health = value;
            EventBus.Instance().OnPlayerHealthChanged(Health, MaxHealth);

            if (_health <= 0)
            {
                EventBus.Instance().OnPlayerDied();
                EventBus.Instance().PlayerDamaging -= TakeDamage;
            }
        }
    }

    public int MaxHealth { get; set; }

    private int _health;

    private void Start()
    {
        MaxHealth = 20;
        Health = MaxHealth;

        EventBus.Instance().PlayerDamaging += TakeDamage;
    }

    private void TakeDamage (int damage)
    {
        Health -= damage;
    }
}
