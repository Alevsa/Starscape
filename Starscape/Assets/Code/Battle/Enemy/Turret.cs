using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    public Transform Focus;
    private ShipCore m_Core;
    public Transform Pointer;
    public float Angle = 75f;
    public float DefaultAngle = 45f;

    void Start()
    {
        m_Core = gameObject.GetComponent<ShipCore>();
    }

    void FixedUpdate()
    {
        AlignTurret();
    }

    void AlignTurret()
    {
        Pointer.LookAt(Focus);
        if (Pointer.rotation.eulerAngles.x > 75f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Pointer.rotation, m_Core.TurnRate * Time.fixedDeltaTime);
        }
        else
        {
            Quaternion temp = Quaternion.Euler(new Vector3(DefaultAngle, 0f, 0f));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, temp, m_Core.TurnRate * Time.fixedDeltaTime);
        }
    }
}
