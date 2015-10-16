using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public float Ammo;
    public float FireRate;
    public float Cooldown;
    public float Damage;

    public virtual void Fire()
    {

    }
}
