using UnityEngine;
using System.Collections;

public class OverworldMovement : MonoBehaviour 
{
//++ TO DO ++
//
// If you switch into m_Speed state 1 then rapidly back to state 0 you will have the incorrect m_Speed.
//
	private OverworldStats m_Stats;
	private float m_Speed = 0f;
	private int m_SpeedState = 0;
	private float m_warpTurning = 1f;
	private Coroutine m_Accelerate;
	private Coroutine m_Decelerate;
	private Coroutine m_Warp;
    public GameObject[] EngineFlare;
	
	void Start () 
	{
		m_Stats = GetComponent<OverworldStats> ();
		m_Stats.Speed = m_Speed;
	}
	

	void Update () 
	{
		Movement();
		m_Stats.Speed = m_Speed;
		//Debug.Log(m_Speed);
	}
	
	public void Turn(float axis)
	{
		transform.Rotate(0f, axis * m_Stats.TurnRate * m_warpTurning * Time.deltaTime, 0f,  Space.World);
	}
	
	// Currently there are two m_Speed states, impulse and warp. warp is very fast has a delay when you start it and difficult to maneouver.
	// impulse is slower but more precise. The idea is you warp between starts and navigate to planets on impulse.
	public void AccelerationHandler(float axis)
	{
		if (axis == 1f)
		{
			switch(m_SpeedState)
			{
				case 0 :
					StopCoroutines();
					m_Accelerate = StartCoroutine(Accelerate(m_Speed, m_Stats.ImpulsePower));
					m_SpeedState++;	
					break;
				case 1 : 
					StopCoroutines();
					m_warpTurning = m_Stats.WarpTurnRate;
					m_Warp = StartCoroutine("Warp");
					m_SpeedState++;
					break;
			}	
		}
		else if (axis == -1f)
		{
			switch(m_SpeedState)
			{ 
				case 1 : 
					StopCoroutines();
					m_Decelerate = StartCoroutine(Decelerate(m_Speed, 0f));
					m_SpeedState--;	
					break;
				case 2 : 
					m_warpTurning = 1f;
					StopCoroutines();
					if(m_Speed > m_Stats.ImpulsePower)
					{
						m_Decelerate = StartCoroutine(Decelerate(m_Speed, m_Stats.ImpulsePower));
					}
					else
					{
						m_Accelerate = StartCoroutine(Accelerate(m_Speed , m_Stats.ImpulsePower));
					}
					m_SpeedState--;
					break;
			}
		}
	}
	
	// If you don't stop them between states then it causes some very odd behavior. Where different coroutines are trying
	// to achieve different things conflicting things. They stop eachother from completing and make stuff happen.
	private void StopCoroutines()
	{
		if (m_Accelerate != null)
			StopCoroutine(m_Accelerate);
		if (m_Decelerate != null)
			StopCoroutine(m_Decelerate);
		if (m_Warp != null)
			StopCoroutine(m_Warp);
	}
	
	private IEnumerator Warp()
	{
        foreach (GameObject flare in EngineFlare)
            flare.SetActive(true);

		for (float i = 0f; i<m_Stats.WarpChargeTime; i+=Time.deltaTime)
		{
			// Exponential function, starts out very low for a while then rapidly grows.
			m_Speed = m_Stats.WarpSpeed*Mathf.Exp(i-m_Stats.WarpChargeTime);
			yield return null;
		}	
	}
	
	private IEnumerator Accelerate(float initial, float target) 
	{	
		for (float i = initial; i<target; i+= m_Stats.Acceleration * Time.deltaTime)
		{
			m_Speed = i;
			yield return null;
		}
	}
	
	private IEnumerator Decelerate(float initial, float target) 
	{
		for (float i = m_Stats.DecelerationTime; i > 0f; i-= Time.deltaTime)
		{
			m_Speed = target + (i/m_Stats.DecelerationTime) * initial;
			yield return null;
		}

        foreach (GameObject flare in EngineFlare)
            flare.SetActive(false);
    }
	
	void Movement () 
	{
		gameObject.transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
		SetToZero();
	}
	
	// Stops slight movement when at a m_Speed ~0.
	void SetToZero()
	{
		if(m_Speed < 0f)
		{
			m_Speed = 0f;
		}
		else if (m_SpeedState == 0f && m_Speed < 0.3f && m_Speed > 0f)
		{
			m_Speed -= 0.08f;
		}
	}
}
