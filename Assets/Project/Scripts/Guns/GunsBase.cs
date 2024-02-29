using TMPro;
using UnityEngine;

public abstract class GunsBase : MonoBehaviour
{
    protected Animator GunAnimator;
    protected TrailRenderer Trail;
    protected Transform FirePoint;
    protected BulletsPool BulletsPool;
    protected TMP_Text AmmoText;
    protected float Timer;
    protected float FireDelay;
    protected float ReloadTime;
    protected float Speed;
    protected int Damage;
    protected bool IsReloading = false;
    protected bool IsFull = true;
    public int MaxAmmo { get; set; }
    public int Ammo
    {
        get => _ammo;
        set { _ammo = value; EventBus.Instance().OnAmmoChanged(Ammo, MaxAmmo); }
    }

    private int _ammo;

    protected virtual void Shoot()
    {
        if (Input.GetMouseButton(0) && Timer >= FireDelay && !IsReloading && Ammo > 0)
        {
            Timer = 0;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPoint = hit.point - transform.position;
                Bullet currentBullet = BulletsPool.CreateBullet(FirePoint.position);
                Ammo -= 1;
                IsFull = false;
                GunAnimator.SetBool("isShooting", true);

                if (currentBullet.TryGetComponent<IProjectile>(out IProjectile projectile))
                {
                    Rigidbody rigidbody = projectile.Rigidbody;
                    projectile.FirePoint = FirePoint;
                    projectile.Damage = Damage;
                    rigidbody.velocity = targetPoint * Speed * Time.deltaTime;
                }
            }
        }

        else if (Input.GetMouseButtonUp(0) || Ammo <= 0 && !IsReloading)
            GunAnimator.SetBool("isShooting", false);
    }
    protected virtual void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && !IsReloading && !IsFull)
        {
            IsReloading = true;
            Trail.enabled = true;
            GunAnimator.SetBool("isReloading", true);
            Invoke("FinishReload", ReloadTime);
        }
    }
    protected virtual void FinishReload()
    {
        IsFull = true;
        IsReloading = false;
        Trail.enabled = false;
        Ammo = MaxAmmo;
        GunAnimator.SetBool("isReloading", false);
    }

    protected virtual void OnWeaponChanged()
    {
        IsReloading = false;
        Trail.enabled = false;
        transform.rotation = transform.parent.rotation;
        GunAnimator.SetBool("isReloading", false);
        CancelInvoke();
    }
}
