﻿using UnityEngine;
using System.Collections;

public class PlanetaryRotation : MonoBehaviour
{
	public float DayLength = 60f;
    private float m_DegreesPerSecond;
	
	void Start()
	{
		m_DegreesPerSecond = 360f / DayLength;
	}
	
	void FixedUpdate () 
	{
		gameObject.transform.Rotate(new Vector3(0f,m_DegreesPerSecond*Time.deltaTime,0f));
	}
}
