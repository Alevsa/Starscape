using UnityEngine;
using System.Collections;
    
abstract public class ShipComponent : MonoBehaviour 
{
	private AudioController m_AudioController;
	public AudioClip[] ExplosionSounds;
	public AudioClip HitExplosionSound;
	public AudioClip CollisionSound = null;
    public int PoolExplosionIndex;
    public int MinGibPoolIndex;
    public int MaxGibPoolIndex;
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

    protected virtual void Start()
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
	
	protected virtual IEnumerator DeathClock(float time)
	{
		for (float i = time; i > -1f; i -= Time.deltaTime)
		{
			//Debug.Log(i);
			if (i<0f)
				Destroy(gameObject);
			yield return null;
		}
	}
	
	protected virtual void DeathAnimation()
	{
		if (ExplosionSounds != null)
		{
			int x = Random.Range(0, ExplosionSounds.Length);
			m_AudioController.PlaySound(ExplosionSounds[x]);
			StartCoroutine("DeathClock", ExplosionSounds[x].length);
		}
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }
        Collider[] collider = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider col in collider)
        {
            col.enabled = false;
        }

        GameObject deathExplosion = ObjectPooler.Current.GetPooledObject(PoolExplosionIndex);
        deathExplosion.transform.position = transform.position;
        deathExplosion.transform.rotation = transform.rotation;
        deathExplosion.SetActive(true);

        for (int i = 0; i < NumberOfGibs; i++)
		{
            int randGib = Random.Range(MinGibPoolIndex, MaxGibPoolIndex);
            GameObject gib = ObjectPooler.Current.GetPooledObject(randGib);
            gib.transform.position = transform.position;
            gib.transform.rotation = transform.rotation;
            gib.SetActive(true);
        }
	}
	
	public virtual void OnCollisionEnter(Collision other)
	{
		Health -= CollisionDamage * MaxHealth;
		//Debug.Log(CollisionSound);
		m_AudioController.PlaySound(CollisionSound);
	}
	
}
