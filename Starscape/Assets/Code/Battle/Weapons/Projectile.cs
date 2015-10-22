using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{
	private float m_Damage;
	private float m_Speed;
	private Vector3 m_Direction;
	private Vector3 m_PrevPosition;
	private LayerMask m_LayerMask;
	
	void Update ()
    {
        MoveForward();
		CheckCollisions();
        Invoke("Destroy", 2f);
	}

	public void SetParams(ProjectileParams param)
	{
		m_Damage = param.Damage;
		m_Speed = param.Speed;
		transform.rotation = param.Transform.rotation;
		m_Direction = param.Transform.forward;
		m_LayerMask = param.HitLayers;
		transform.Rotate(90, 0, 0);
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
		if(Physics.Linecast(m_PrevPosition, transform.position, out hit, m_LayerMask))
		{
			Debug.Log ("Collision!");
			hit.transform.gameObject.SendMessage("TakeDamage", m_Damage);
			Destroy ();
		}

		m_PrevPosition = transform.position;
	}
}
