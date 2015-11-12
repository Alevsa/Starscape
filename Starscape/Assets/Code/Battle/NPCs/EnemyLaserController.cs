using UnityEngine;
using System.Collections;

public class EnemyLaserController : MonoBehaviour
{
    public LayerMask WeaponsLayer;
    private WeaponController m_Weapon;
    public Transform[] FiringPoints;
    private Transform Focus;
    private TargetingComputer m_TargetingComputer;

    void Start ()
    {
        m_TargetingComputer = gameObject.GetComponent<TargetingComputer>();
        m_Weapon = gameObject.GetComponent<WeaponController>();
        if (FiringPoints.Length == 0)
        {
            FiringPoints = new Transform[1];
            FiringPoints[0] = transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (Focus == null && m_TargetingComputer.Focus != null)
        {
            Focus = m_TargetingComputer.Focus;
        }
        FireControl();
	}

    void FireControl()
    {
        foreach (Transform pos in FiringPoints)
        {
            //Debug.DrawLine(pos.position, pos.forward*400f, Color.white);
            if (Physics.Raycast(pos.position, transform.forward, Mathf.Infinity, WeaponsLayer) && Focus != null)
            {
                m_Weapon.FirePrimaryWeaponHold();
                break;
            }
        }
    }
}
