using UnityEngine;

public interface IProjectile
{
    public Rigidbody Rigidbody { get; }
    public Transform FirePoint { get; set; }
    public int Damage { get; set; }
}
