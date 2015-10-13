﻿using UnityEngine;
using System.Collections;

public class BattleCamera : MonoBehaviour 
{
/*
	private GameObject m_Focus;
	private BattleMovement m_Movement; 
	private GameObject m_Pointer;
	public float RotateSpeed = 2f;
	public float ZoomFactor = 0.006f;
	public float CameraOffset = 7f;

	void Start()
	{
		m_Focus = GameObject.FindGameObjectWithTag("PlayerBattle");
		m_Movement = m_Focus.GetComponent<BattleMovement>();
		#region Get pointer
		for (int i = 0; i<transform.childCount; i++)
		{	
			GameObject obj = transform.GetChild(i).gameObject;
			if (obj.tag == "Pointer")
			{
				m_Pointer = obj;
			}
		}
		#endregion
	}
	
	void Update()
	{
		Debug.Log(m_Focus.transform.forward);
		m_Pointer.transform.LookAt(m_Focus.transform);
		gameObject.transform.position = m_Focus.transform.position + (-1f) * m_Focus.transform.forward * ZoomFactor * Mathf.Abs(m_Movement.Speed) - m_Focus.transform.forward * CameraOffset;
		gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, m_Focus.transform.rotation, RotateSpeed); 
	}
	*/
	
	public Transform Target;
	public float Distance = 5f;
	public float Height = 4f;
	
	public float RotationDamping = 3f;
	
	
	void LateUpdate () 
	{
		CameraChase();
	}
	
	void CameraChase()
	{
		if (!Target)
			return;
		
		var wantedRotationAngleSide = Target.eulerAngles.y;
		var currentRotationAngleSide = transform.eulerAngles.y;
		
		var wantedRotationAngleUp = Target.eulerAngles.x;
		var currentRotationAngleUp = transform.eulerAngles.x;
		
		currentRotationAngleSide = Mathf.LerpAngle(currentRotationAngleSide, wantedRotationAngleSide, RotationDamping * Time.deltaTime);
		
		currentRotationAngleUp = Mathf.LerpAngle(currentRotationAngleUp, wantedRotationAngleUp, RotationDamping * Time.deltaTime);
		
		var currentRotation = Quaternion.Euler(currentRotationAngleUp, currentRotationAngleSide, 0);
		
		transform.position = Target.position;
		transform.position -= currentRotation * Vector3.forward * Distance;
		
		transform.LookAt(Target);
		
		transform.position += transform.up * Height;
	}
	
}