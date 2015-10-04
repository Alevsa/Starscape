using UnityEngine;
using System.Collections;

public class OverworldMovement : MonoBehaviour {

	private OverworldStats stats;
	private float speed = 0f;
	private int speedState = 0;
	private float warpTurning = 1f;
	
	void Start () 
	{
		stats = GetComponent<OverworldStats> ();
	}
	

	void Update () 
	{
		movement();
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
					StartCoroutine("Decelerate", stats.impulsePower);
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
	}
}
