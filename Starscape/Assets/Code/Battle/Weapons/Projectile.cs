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
    private Transform m_InitTrans;
    public GameObject Explosion;

	void FixedUpdate ()
    {
        Move();
		CheckCollisions();
        Invoke("Destroy", 2f);
	}

	public void SetParams(float dmg, float speed, Vector3 direction, Transform firingPoint, LayerMask hitLayer)
	{
		m_Damage = dmg;
		m_Speed = speed;
		m_HitLayers = hitLayer;

        m_Direction = direction;
        transform.position = firingPoint.position;
        transform.rotation = firingPoint.rotation;
        m_InitTrans = firingPoint;
	}

    protected virtual void Move()
    {
        transform.position += m_Direction * m_Speed * Time.deltaTime;
    }

    protected virtual void Destroy()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

	protected virtual void CheckCollisions()
	{
		RaycastHit hit;
		if(Physics.Linecast(m_PrevPosition, transform.position, out hit, m_HitLayers))
		{
			ShipComponent hitThing = hit.transform.gameObject.GetComponent<ShipComponent>();
			if (hitThing != null)
			{
				hitThing.TakeDamage(m_Damage);
			}
		
			Instantiate(Explosion, transform.position, transform.rotation);
            transform.position = m_InitTrans.position;
			Destroy ();
		}

        m_PrevPosition = transform.position;
	}
}
