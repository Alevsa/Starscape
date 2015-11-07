using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour
{
    public float CrosshairDistance;
    private Transform m_Crosshair;

	// Use this for initialization
	void Start ()
    {
        m_Crosshair = transform.Find("Crosshair");
	}
	
	void FixedUpdate ()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, CrosshairDistance))
        {
            if (hit.transform.gameObject.tag != "Projectile")
                m_Crosshair.position = hit.point - transform.forward * 10;
        }

        else
            m_Crosshair.position = transform.position + transform.forward * (CrosshairDistance -10);
    }
}
