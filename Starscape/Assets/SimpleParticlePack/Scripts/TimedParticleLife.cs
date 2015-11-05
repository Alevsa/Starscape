using UnityEngine;
using System.Collections;

public class TimedParticleLife : MonoBehaviour 
{
	private float Timer = 0f;
	private ParticleSystem m_p;
	// Use this for initialization
	void Start () 
	{
		Timer = 10f;
		m_p = gameObject.GetComponent<ParticleSystem>();
	}
	
	void Update () 
	{	
		Debug.Log(Timer);
		Timer += Time.deltaTime;
		if (m_p && Timer > 10f)
		{
			if (m_p.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}
