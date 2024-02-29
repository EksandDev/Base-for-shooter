using UnityEngine;

public class Machinegun : GunsBase
{
    [SerializeField] private BulletsPool _bulletsPool;

    private void Awake()
    {
        GunAnimator = GetComponent<Animator>();
        Trail = transform.GetChild(1).GetComponent<TrailRenderer>();

        FirePoint = transform.GetChild(0);
        BulletsPool = _bulletsPool;
        FireDelay = 0.1f;
        Speed = 150;
        Damage = 10;
        MaxAmmo = 100;
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
}
