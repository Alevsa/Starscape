using UnityEngine;
using System.Collections;

abstract public class ShipComponent : MonoBehaviour 
{
	private AudioSource m_ExplosionSound;
	public AudioClip[] ExplosionSounds;
	public AudioClip HitExplosionSound;
	public GameObject Explosion;
	public GameObject[] Gibs;
	public int NumberOfGibs = 4;
	
	
	public float TurnRate;
	public float Acceleration;
	public float Deceleration;
	public float MaxSpeed;
	public float MaxReverseSpeed;
	public float MaxHealth;
	public float Health;
	public float Armour;
	public bool Alive = true;
	[HideInInspector]public float Speed;
	public float RollRate;
	//public int DeathExplosions = 3;
	
	public virtual void Start()
	{
		NumberOfGibs += Random.Range(0, 4);
		m_ExplosionSound = gameObject.GetComponent<AudioSource>();
	}
	
	public virtual void TakeDamage(float damage)
	{	
		m_ExplosionSound.clip = HitExplosionSound;
		m_ExplosionSound.Play();
		if (damage - Armour <= 0)
			Health -= 1;				
		else
			Health -= damage - Armour;
	}
	
	protected virtual void DeathAnimation()
	{
		if (m_ExplosionSound != null)
		{
			m_ExplosionSound.clip = ExplosionSounds[Random.Range(0, ExplosionSounds.Length)];
			m_ExplosionSound.Play();
		}		
		GameObject deathExplosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
		for (int i = 0; i < NumberOfGibs; i++)
		{
			Instantiate(Gibs[Random.Range(0, Gibs.Length)], transform.position, transform.rotation);
		}
	}
	
}
