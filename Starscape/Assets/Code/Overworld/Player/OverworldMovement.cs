using UnityEngine;
using System.Collections;

public class OverworldMovement : MonoBehaviour 
{
//++ TO DO ++
//
// If you switch into speed state 1 then rapidly back to state 0 you will have the incorrect speed.
	private OverworldStats stats;
	private float speed = 0f;
	private int speedState = 0;
	private float warpTurning = 1f;
	
	void Start () 
	{
		stats = GetComponent<OverworldStats> ();
		stats.speed = speed;
	}
	

	void Update () 
	{
		movement();
		stats.speed = speed;
		Debug.Log(speed);
	}
	
	public void turn(float axis)
	{
		transform.Rotate(0f, axis * stats.turnRate * warpTurning * Time.deltaTime, 0f,  Space.World);
	}
	
	// Currently there are two speed states, impulse and warp. warp is very fast has a delay when you start it and difficult to maneouver.
	// impulse is slower but more precise. The idea is you warp between starts and navigate to planets on impulse.
	public void accelerationHandler(float axis)
	{
		if (axis == 1f)
		{
			switch(speedState)
			{
				case 0 : 
					StartCoroutine("Accelerate", stats.impulsePower);
					speedState++;	
					break;
				case 1 : 
					warpTurning = stats.warpTurnRate;
					StartCoroutine("Warp");
					speedState++;
					break;
			}
			
		}
		else if (axis == -1f)
		{
			switch(speedState)
			{ 
				case 1 : 
					StartCoroutine("Decelerate", 0f);
					speedState--;	
					break;
				case 2 : 
					warpTurning = 1f;
					StopCoroutine("Warp");
					if(speed > stats.impulsePower)
					{
						StartCoroutine("Decelerate", stats.impulsePower);
					}
					else
					{
						StartCoroutine("Accelerate", stats.impulsePower);
					}
					speedState--;
					break;
			}
		}
	}
	
	private IEnumerator Warp()
	{
		for (float i = 0f; i<stats.warpChargeTime; i+=Time.deltaTime)
		{
			// Exponential function, starts out very low for a while then rapidly grows.
			speed = stats.warpSpeed*Mathf.Exp(i-stats.warpChargeTime);
			yield return null;
		}	
	}
	
	private IEnumerator Accelerate(float amount) 
	{	
		while (speed < amount)
		{
			speed += stats.acceleration;
			yield return null;
		}
	}
	
	private IEnumerator Decelerate(float amount) 
	{
		while (speed > amount)
		{
			speed -= stats.acceleration;
			yield return null;
		}
	}
	
	void movement () 
	{
		gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		setToZero();
	}
	
	// Stops slight movement when at a speed ~0.
	void setToZero()
	{
		if(speed < 0f)
		{
			speed = 0f;
		}
		else if (speedState == 0f && speed < 0.3f && speed > 0f)
		{
			speed -= 0.08f;
		}
	}
}
