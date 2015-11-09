using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour
{
    public float CrosshairDistance = 50f;
 	public Transform Player;
	
	void FixedUpdate ()
    {
        if (Player != null)
        {
            gameObject.SetActive(true);
            transform.rotation = Player.rotation;
            RaycastHit hit;

            if (Physics.Raycast(Player.position, Player.forward, out hit, CrosshairDistance))
            {
                if (hit.transform.gameObject.tag != "Projectile")
                    transform.position = hit.point - transform.forward * 10;
            }

            else
                transform.position = Player.position + Player.forward * (CrosshairDistance - 10);
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
