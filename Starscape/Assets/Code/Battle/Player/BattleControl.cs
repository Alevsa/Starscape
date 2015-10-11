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
		
		if (Input.GetAxisRaw("Accelerate") == -1)
		{
			m_HandlerMovement.Decelerate();
		}
		else if (Input.GetAxisRaw("Accelerate") == 1)
		{
			m_HandlerMovement.Accelerate();
		}	
		Debug.Log(Input.GetAxis("Joystick Y"));
		m_HandlerMovement.HandleMouse(Input.GetAxis("Joystick X"), Input.GetAxis("Joystick Y"));	
	}
	
	
	// TO DO: Make these methods convert mouse position to values like the joystick movement
	float GetYAxis()
	{
		return 0f;
	}
	
	float GetXAxis()
	{
		return 0f;
	}
	
	// Delete this
	void RotateShip()
	{
		m_HandlerMovement.HandleMouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
	}
}
