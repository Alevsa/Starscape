using UnityEngine;
using System.Collections;

public class TurretHardpoint : MonoBehaviour
{
    private ShipPeripheral m_Turret;
    private ShipPeripheral m_Me;

    void Start()
    {
        m_Turret = gameObject.GetComponentInChildren<ShipPeripheral>();
        m_Me = gameObject.GetComponent<ShipPeripheral>();
    }

    void FixedUpdate()
    {
        if (!m_Me.Alive && m_Turret.Alive)
        {
            m_Turret.Health -= m_Turret.Health;
        }
    }

}
