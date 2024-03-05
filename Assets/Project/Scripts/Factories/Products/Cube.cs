using UnityEngine;
using UnityEngine.AI;

public class Cube : Enemy
{
    protected override void Attack()
    {
        EventBus.Instance().OnPlayerDamaging(Damage);
    }

    protected override void Move()
    {
        Agent.SetDestination(Target.position);
    }

    private void Awake()
    {
        Initialize(transform.GetComponent<NavMeshAgent>(), GameObject.Find("Player").transform, 20, 20, 10);
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            Attack();
        }
    }
}
