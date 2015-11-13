using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour
{
    private TargetingComputer m_TargetingComputer;
    public Transform Focus;
    private ShipPeripheral m_TurretCore;
    public Transform Pointer;
    public float Angle = 75f;
    public float DefaultAngle = 45f;

    void Start()
    {
        m_TargetingComputer = gameObject.GetComponent<TargetingComputer>();
        m_TurretCore = gameObject.GetComponent<ShipPeripheral>();
    }

    void FixedUpdate()
    {
        if (Focus == null)
        {
            Focus = m_TargetingComputer.Focus;
        }
        else
        {
            AlignTurret();
        }
    }

    void AlignTurret()
    {
        Pointer.LookAt(Focus);
        if (Pointer.rotation.eulerAngles.x > 75f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Pointer.rotation, m_TurretCore.TurnRate * Time.fixedDeltaTime);
        }
        else
        {
            Focus = null;
            Quaternion temp = Quaternion.Euler(new Vector3(DefaultAngle, 0f, 0f));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, temp, m_TurretCore.TurnRate * Time.fixedDeltaTime);
        }
    }
}
