using UnityEngine;

public class Pistol : GunsBase
{
    [SerializeField] private BulletsPool _bulletsPool;

    private void Awake()
    {
        GunAnimator = GetComponent<Animator>();
        Trail = transform.GetChild(1).GetComponent<TrailRenderer>();

        FirePoint = transform.GetChild(0);
        BulletsPool = _bulletsPool;
        FireDelay = 0.4f;
        Speed = 150;
        Damage = 3;
        MaxAmmo = 7;
        Ammo = MaxAmmo;
        ReloadTime = 1;
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
