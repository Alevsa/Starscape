using UnityEngine;
using System.Collections;

public class ShipCore : ShipComponent
{
	public GameObject Explosion;
	public GameObject[] Gibs;
	private AudioSource m_ExplosionSound;
	
	private ShipPeripheral[] m_ShipPeripherals; 
	void Start () 
	{
		m_ExplosionSound = gameObject.GetComponent<AudioSource>();
		m_ShipPeripherals = GetComponentsInChildren<ShipPeripheral>();
		Alive = true;
		foreach(ShipPeripheral peripheral in m_ShipPeripherals)
		{
			TurnRate += peripheral.TurnRate;
			Acceleration += peripheral.Acceleration;
			Deceleration += peripheral.Deceleration;
			MaxSpeed += peripheral.MaxSpeed;
			MaxHealth += peripheral.MaxHealth;
			MaxReverseSpeed += peripheral.MaxReverseSpeed;
			RollRate += peripheral.RollRate;
		}
	}
	
	void Update()
	{
		if (Health <= 0 && Alive)
			Die ();
	}
	
	void Die()
	{	
		Debug.Log("Dead");
		WeaponController weapons = gameObject.GetComponent<WeaponController>();
		if (weapons != null)
		{
			weapons.Alive = false;
		}
		Alive = false;
		TurnRate = 0f;
		Acceleration = 0f;
		Deceleration = 0f;
		RollRate = 0f;
		DeathAnimation();
		//StartCoroutine("DeathAnimation");
	}
	
	void DeathAnimation()
	{
		if (m_ExplosionSound != null)
			m_ExplosionSound.Play();
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		foreach (Renderer r in renderers)
		{
			r.enabled = false;
		}
		Collider[] collider = gameObject.GetComponents<Collider>();
		foreach (Collider col in collider)
		{
			col.enabled = false;
		}
		
		GameObject deathExplosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
		deathExplosion.transform.SetParent(transform);
		int numberOfGibs = Random.Range(4, 8);
		for (int i = 0; i < numberOfGibs; i++)
		{
			Instantiate(Gibs[Random.Range(0, Gibs.Length)], transform.position, transform.rotation);
		}
	}
}
