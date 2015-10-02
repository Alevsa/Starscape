using UnityEngine;
using System.Collections;

public class OverworldMovement : MonoBehaviour {

	private OverworldStats stats;
	private float speed = 0f;
	
	private Vector3 forwardForce;
	
	void Start () 
	{
		stats = GetComponent<OverworldStats> ();
	}
	

	void Update () 
	{
		Debug.Log(speed);
		movement();
	}
	
	public void turn(float axis)
	{
		transform.Rotate(new Vector3(0f, axis * stats.turnRate, 0f));
	}
	
	public void accelerationHandler(float axis)
	{
		if (axis == 1f)
		{
			StartCoroutine("Accelerate");	
		}
		else if (axis == -1f)
		{
			StartCoroutine("Decelerate");
		}
	}
	
	private IEnumerator ImpulsePower()
	{
		
	}
	
	private IEnumerator WarpSpeed()
	{
	
	}
	
	private IEnumerator Accelerate() 
	{
		
		while (speed < stats.maxSpeed)
		{
			speed += stats.acceleration;
			yield return null;
		}
	}
	
	private IEnumerator Decelerate() 
	{
		while (speed > 0f)
		{
			speed -= stats.acceleration;
			yield return null;
		}
	}
	
	void movement () 
	{
		transform.position += transform.forward * speed * 0.0001f;
	}
}
