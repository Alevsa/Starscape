using UnityEngine;
using System.Collections;

public class BattleControl : MonoBehaviour 
{	
	//Ship to be controlled
	public GameObject Ship;
	private BattleMovement m_HandlerMovement;
	private float m_RotDamping;
	
	public GameObject debugging;
	
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
		m_HandlerMovement.PitchYaw(Input.GetAxis("Joystick X"), Input.GetAxis("Joystick Y"));
	}
	
	float MouseYToJoyStickAxis()
	{
		return 0f;
	}
	
	float MouseXToJoyStickAxis()
	{
		return 0f;
	}
}
