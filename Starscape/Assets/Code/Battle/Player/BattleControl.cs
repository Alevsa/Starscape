﻿using UnityEngine;
using System.Collections;

public class BattleControl : MonoBehaviour 
{	
	//Ship to be controlled
	public GameObject Ship;
	public bool MouseControls = false;
	private BattleMovement m_HandlerMovement;
	private float m_RotDamping;
	public float Deadzone = 0.05f;
	
	// Use this for initialization
	void Start () 
	{
		Ship = GameObject.FindGameObjectWithTag("PlayerBattle");
		m_HandlerMovement = Ship.GetComponent<BattleMovement>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		InGameInput ();
	}
	
	void MenuInput() {
		
	}
	
	//In-game handling
	void InGameInput() 
	{
	
		if (Input.GetAxisRaw("Accelerate") == -1f)
			m_HandlerMovement.Decelerate();
		else if (Input.GetAxisRaw("Accelerate") == 1f)
			m_HandlerMovement.Accelerate();
		else if (Input.GetAxisRaw("Hand Brake") == 1f)
			m_HandlerMovement.HandBrake();		
		if (Input.GetAxisRaw("Stabilise") == 1f)
			m_HandlerMovement.SnapRotation();
		
		
		m_HandlerMovement.Roll(Input.GetAxisRaw("Roll"));
		if (MouseControls)
			m_HandlerMovement.PitchYaw(MouseXToJoyStickAxis(), MouseYToJoyStickAxis());
		else
			m_HandlerMovement.PitchYaw(Input.GetAxis("Joystick X"), Input.GetAxis("Joystick Y"));
	}
	
	#region Converts mouse coordinates to joystick input, imagine the mouse cursor as the top of the joystick, that's how it works.
	float MouseYToJoyStickAxis()
	{
		float y = ((Input.mousePosition.y - (0.5f * Screen.height)) / Screen.height) * 2f;  
		if (Mathf.Abs(y) < Deadzone)
			return 0;
		else return y;
	}
	
	float MouseXToJoyStickAxis()
	{
		float x = ((Input.mousePosition.x - (0.5f * Screen.width)) / Screen.width) * 2f;  
		if (Mathf.Abs(x) < Deadzone)
			return 0;
		else return x;
	}
	#endregion
}
