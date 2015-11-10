using UnityEngine;
using System.Collections;

public class EnemyLaserController : MonoBehaviour
{
    public LayerMask WeaponsLayer;
    private WeaponController m_Weapon;
    public Transform[] FiringPoints;
    public GameObject Focus;

    void Start ()
    {
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
        FireControl();
	}

    void FireControl()
    {
        foreach (Transform pos in FiringPoints)
        {
            Debug.DrawLine(pos.position, pos.forward*400f, Color.white);
            if (Physics.Raycast(pos.position, transform.forward, Mathf.Infinity, WeaponsLayer) && Focus != null)
            {
                m_Weapon.FirePrimaryWeaponHold();
                break;
            }
        }
    }
}
