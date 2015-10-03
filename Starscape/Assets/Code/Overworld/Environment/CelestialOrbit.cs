using UnityEngine;
using System.Collections;

public class CelestialOrbit : MonoBehaviour 
{
	public GameObject focus;
	public bool clockwise;
	public float orbitalPeriod = 450f;
	private float orbitalSpeed = 360f/60f;
	private Vector3 axis = Vector3.down;
	
	void Start()
	{
		if (clockwise)
		{
			axis = Vector3.up;
		}
		else 
		{
			axis = Vector3.down;
		}
		orbitalSpeed = 360f/orbitalPeriod;
	}
	
	void Update()
	{
		transform.RotateAround(focus.transform.position, axis, orbitalSpeed*Time.deltaTime);
	}


}
