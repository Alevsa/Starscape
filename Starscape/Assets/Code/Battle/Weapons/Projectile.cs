using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{
	private float m_Damage;
	private float m_Speed;
	private Vector3 m_Direction;
	private Vector3 m_PrevPosition;
	private LayerMask m_HitLayers;
	
	void Update ()
    {
        MoveForward();
		CheckCollisions();
        Invoke("Destroy", 2f);
	}

	public void SetParams(float dmg, float speed, Transform firingPoint, LayerMask hitLayer)
	{
		m_Damage = dmg;
		m_Speed = speed;
		m_HitLayers = hitLayer;

        m_Direction = firingPoint.forward;
        transform.position = firingPoint.position;
        transform.rotation = firingPoint.rotation;
	}

    protected virtual void MoveForward()
    {
        transform.position += m_Direction * m_Speed * Time.deltaTime;
    }

    protected virtual void Destroy()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }

	protected virtual void CheckCollisions()
	{
		RaycastHit hit;
		if(Physics.Linecast(m_PrevPosition, transform.position, out hit, m_HitLayers))
		{
			Debug.Log ("Collision! - " + hit.transform.gameObject.name);
			hit.transform.gameObject.SendMessage("TakeDamage", m_Damage);
			Destroy ();
		}

		m_PrevPosition = transform.position;
	}
}
