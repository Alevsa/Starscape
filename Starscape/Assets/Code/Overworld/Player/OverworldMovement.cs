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
					StartCoroutine("Accelerate", m_Stats.ImpulsePower);
					m_SpeedState++;	
					break;
				case 1 : 
					StopCoroutines();
					m_warpTurning = m_Stats.WarpTurnRate;
					StartCoroutine("Warp");
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
					StartCoroutine("Decelerate", 0f);
					m_SpeedState--;	
					break;
				case 2 : 
					m_warpTurning = 1f;
					StopCoroutines();
					if(m_Speed > m_Stats.ImpulsePower)
					{
						StartCoroutine("Decelerate", m_Stats.ImpulsePower);
					}
					else
					{
						StartCoroutine("Accelerate", m_Stats.ImpulsePower);
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
		StopCoroutine("Accelerate");
		StopCoroutine("Decelerate");
		StopCoroutine("Warp");
	}
	
	private IEnumerator Warp()
	{
		for (float i = 0f; i<m_Stats.WarpChargeTime; i+=Time.deltaTime)
		{
			// Exponential function, starts out very low for a while then rapidly grows.
			m_Speed = m_Stats.WarpSpeed*Mathf.Exp(i-m_Stats.WarpChargeTime);
			yield return null;
		}	
	}
	
	private IEnumerator Accelerate(float amount) 
	{	
		while (m_Speed < amount)
		{
			m_Speed += m_Stats.Acceleration;
			yield return null;
		}
	}
	
	private IEnumerator Decelerate(float amount) 
	{
		while (m_Speed > amount)
		{
			m_Speed -= m_Stats.Acceleration;
			yield return null;
		}
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
