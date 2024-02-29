using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile, IInPool
{
    public Rigidbody Rigidbody { get; private set; }
    public Transform FirePoint { get; set; }
    public int Damage { get; set; }
    public bool IsActive { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        IsActive = false;
    }

    private void OnEnable()
    {
        IsActive = true;
    }

    private void OnDisable()
    {
        IsActive = false;
        transform.position = FirePoint.position;
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
            damageable.TakeDamage(Damage);

        Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
