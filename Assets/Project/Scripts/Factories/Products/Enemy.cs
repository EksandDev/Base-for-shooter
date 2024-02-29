using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected NavMeshAgent Agent;
    protected Transform Target;
    protected int Health;
    protected int MaxHealth;
    protected int Damage;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        EventBus.Instance().OnEnemyDied();

        if (Health <= 0)
        {
            Health = 0;
            Destroy(gameObject);
        }
    }

    protected void Initialize(NavMeshAgent agent, Transform target, int health, int maxHealth, int damage)
    {
        Agent = agent;
        Target = target;
        Health = health;
        MaxHealth = maxHealth;
        Damage = damage;
    }

    protected abstract void Move();

    protected abstract void Attack();
}
