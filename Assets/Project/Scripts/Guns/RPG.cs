using UnityEngine;

public class RPG : GunsBase
{
    [SerializeField] private GameObject _missle;

    private int _damage = 50;

    private void Awake()
    {
        GunAnimator = GetComponent<Animator>();
        Trail = transform.GetChild(1).GetComponent<TrailRenderer>();

        FirePoint = transform.GetChild(0);
        FireDelay = 0;
        Speed = 150;
        Damage = 50;
        MaxAmmo = 1;
        Ammo = MaxAmmo;
        ReloadTime = 6;
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        Shoot();
        Reload();
    }

    private void OnEnable()
    {
        EventBus.Instance().WeaponChanged += OnWeaponChanged;
    }

    private void OnDisable()
    {
        EventBus.Instance().WeaponChanged -= OnWeaponChanged;
    }

    protected override void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Timer >= FireDelay && !IsReloading && Ammo > 0)
        {
            Timer = 0;
            IsFull = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPoint = hit.point - transform.position;
                Ammo -= 1;
                _missle.SetActive(false);
                GunAnimator.SetBool("isShooting", true);

                foreach (var item in Physics.OverlapSphere(transform.position, 10))
                {
                    if (item.TryGetComponent<IDamageable>(out IDamageable damageable))
                    {
                        damageable.TakeDamage(_damage);
                    }
                }
            }
        }

        else if (Input.GetMouseButtonUp(0) || Ammo <= 0 && !IsReloading)
            GunAnimator.SetBool("isShooting", false);
    }

    protected override void FinishReload()
    {
        IsFull = true;
        IsReloading = false;
        Trail.enabled = false;
        _missle.SetActive(true);
        Ammo = MaxAmmo;
        GunAnimator.SetBool("isReloading", false);
    }
}
