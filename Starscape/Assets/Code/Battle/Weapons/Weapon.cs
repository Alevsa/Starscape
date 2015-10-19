using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public float Ammo;
    public float FireRate;
    protected float m_Timer;

    void Update()
    {
        m_Timer += Time.deltaTime;
    }

    public virtual void Fire(List<Transform> firingPoints)
    {
    }
}
