using UnityEngine;
using System.Collections;

public class ShipPeripheral : ShipComponent
{
    private ShipCore m_Core;
    public ShipCore ExternalCore;

    protected override void Start()
    {
        base.Start();
        Alive = true;
        m_Core = transform.GetComponentInParent<ShipCore>();
        if (m_Core == null)
        {
            m_Core = ExternalCore;
        }

    }

    void FixedUpdate()
    {
        if (Health <= 0f && Alive)
            Disabled();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        //Debug.Log("hit");
        if (m_Core != null)
        {
            m_Core.Health -= damage;
        }
    }

    void Disabled()
    {
        Alive = false;
        if (m_Core != null)
        {
            m_Core.TurnRate -= TurnRate;
            m_Core.Acceleration -= Acceleration;
            m_Core.Deceleration -= Deceleration;
            m_Core.MaxSpeed -= MaxSpeed;
            m_Core.MaxReverseSpeed -= MaxReverseSpeed;
            m_Core.RollRate -= RollRate;
        }
        DeathAnimation();
        KillChildren();
    }
}
