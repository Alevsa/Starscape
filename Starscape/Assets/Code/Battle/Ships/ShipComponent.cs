using UnityEngine;
using System.Collections;

abstract public class ShipComponent : MonoBehaviour 
{
	private AudioController m_AudioController;
	public AudioClip[] ExplosionSounds;
	public AudioClip HitExplosionSound;
	public AudioClip CollisionSound = null;
	public GameObject Explosion;
	public GameObject[] Gibs;
	public int NumberOfGibs = 4;
	public float CollisionDamage = 0.25f;
	
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
		/*if (CollisionSound = null)
		{
			CollisionSound = HitExplosionSound;
		}*/
		NumberOfGibs += Random.Range(0, 4);
		m_AudioController = gameObject.GetComponent<AudioController>();
	}
	
	public virtual void TakeDamage(float damage)
	{	
		if (HitExplosionSound != null)
		{
			m_AudioController.PlaySound(HitExplosionSound);
		}
		
		if (damage - Armour <= 0)
			Health -= 1;				
		else
			Health -= damage - Armour;
	}
	
	protected virtual void DeathAnimation()
	{
		if (ExplosionSounds != null)
		{
			m_AudioController.PlaySound(ExplosionSounds[Random.Range(0, ExplosionSounds.Length)]);
		}		
		GameObject deathExplosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
		for (int i = 0; i < NumberOfGibs; i++)
		{
			Instantiate(Gibs[Random.Range(0, Gibs.Length)], transform.position, transform.rotation);
		}
	}
	
	public virtual void OnCollisionEnter(Collision other)
	{
		Health -= CollisionDamage * MaxHealth;
		//Debug.Log(CollisionSound);
		m_AudioController.PlaySound(CollisionSound);
	}
	
}
