using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected BloodEffectsPool BloodEffectsPool;
    protected NavMeshAgent Agent;
    protected Transform Target;
    protected int Health;
    protected int MaxHealth;
    protected int Damage;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        BloodEffectsPool.CreateEffect(transform.position);
        

        if (Health <= 0)
        {
            Health = 0;
            EventBus.Instance().OnEnemyDied();
            Destroy(gameObject);
        }
    }

    protected void Initialize
        (NavMeshAgent agent, Transform target, int health, int maxHealth, int damage)
    {
        Agent = agent;
        Target = target;
        Health = health;
        MaxHealth = maxHealth;
        Damage = damage;

        BloodEffectsPool = FindAnyObjectByType<BloodEffectsPool>();
    }

    protected abstract void Move();

    protected abstract void Attack();
}
