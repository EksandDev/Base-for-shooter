using UnityEngine;
using UnityEngine.AI;

public class Cube : Enemy
{
    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move()
    {
        Agent.SetDestination(Target.position);
    }

    private void Awake()
    {
        base.Initialize(transform.GetComponent<NavMeshAgent>(), GameObject.Find("Player").transform, 20, 20, 10);
    }

    private void Update()
    {
        Move();
    }
}
