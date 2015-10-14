using UnityEngine;
using System.Collections;

public class CelestialOrbit : MonoBehaviour 
{
	public GameObject Focus;
	public bool Clockwise;
	public float OrbitalPeriod = 450f;
	private float m_OrbitalSpeed = 360f/60f;
	private Vector3 m_Axis = Vector3.down;
	
	void Start()
	{
		if (Clockwise)
		{
			m_Axis = Vector3.up;
		}
		else 
		{
			m_Axis = Vector3.down;
		}
		m_OrbitalSpeed = 360f/OrbitalPeriod;
	}
	
	void Update()
	{
		transform.RotateAround(Focus.transform.position, m_Axis, m_OrbitalSpeed*Time.deltaTime);
	}


}
