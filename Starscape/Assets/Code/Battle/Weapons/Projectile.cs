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

	public void SetParams(float dmg, float speed, Transform firingPoint, LayerMask hitLayer)
	{
		m_Damage = dmg;
		m_Speed = speed;
		m_HitLayers = hitLayer;

        m_Direction = firingPoint.forward;
        //m_Direction += firingPoint.right * Input.GetAxis("Horizontal");
        //m_Direction += firingPoint.up * Input.GetAxis("Vertical");
        m_Direction.Normalize();
//        Debug.Log(m_Direction);
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
			//Debug.Log ("Collision! - " + hit.transform.gameObject.name);
			ShipComponent hitThing = hit.transform.gameObject.GetComponent<ShipComponent>();
			if (hitThing != null)
			{
				hitThing.TakeDamage(m_Damage);
			}
		// Doesn't work, not sure if it's even efficient to use object pooling in this situation
		/*	GameObject obj = ObjectPooler.Current.GetPooledObject(2);
			obj.GetComponent<ParticleSystem>().Play();
			obj.transform.parent = gameObject.transform;
			obj.transform.position = gameObject.transform.position;*/
		
			Instantiate(Explosion, transform.position, transform.rotation);
            transform.position = m_InitTrans.position;
			Destroy ();
		}

        m_PrevPosition = transform.position;
	}
}
