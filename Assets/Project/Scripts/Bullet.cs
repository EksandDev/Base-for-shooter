using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile, IInPool
{
    public Rigidbody Rigidbody { get; private set; }
    public Transform FirePoint { get; set; }
    public int Damage { get; set; }
    public bool IsActive { get; set; }

    private TrailRenderer _trail;
    private Transform _parent;

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _trail = GetComponent<TrailRenderer>();
        IsActive = false;
    }

    private void Start()
    {
        _parent = transform.parent; 
    }

    private void OnEnable()
    {
        IsActive = true;
        transform.parent = null;
        Invoke(nameof(Deactivate), 3);
    }

    private void OnDisable()
    {
        IsActive = false;
        transform.parent = _parent;
        transform.position = _parent.position;
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
            damageable.TakeDamage(Damage);

        Deactivate();
    }
}
