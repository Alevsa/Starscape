using UnityEngine;
using System.Collections;

public class TimedParticleLife : MonoBehaviour 
{

	private ParticleSystem m_p;
	// Use this for initialization
	void Start () 
	{
		m_p = gameObject.GetComponent<ParticleSystem>();
	}
	
	void Update () 
	{
		if (m_p)
		{
			if (m_p.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}
