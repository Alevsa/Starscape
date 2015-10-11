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
		
		m_HandlerMovement.HandleMouse(GetXAxis(), GetYAxis());		
	}
	
	
	// TO DO: Make the deadzone percentage based rather than an absolute value.
	float GetYAxis()
	{
		// If not in the deadzone then return -1 in lower half of the screen and +1 in top half of the screen, else return 0.
		// This is meant to be the equation for a circle by the way.
		if (Mathf.Pow(Input.mousePosition.y - (Screen.height/2f), 2f) > Mathf.Pow(m_HandlerMovement.Deadzone, 2f))
		{
			if (Input.mousePosition.y < Screen.height / 2 )
			{	
				//Debug.Log("Down");
				return -1f;
			}
			else
			{
				//Debug.Log("Up");
				return 1f;
			}
		}
		else 
		{
			//Debug.Log("neutral");
			return 0f;
		}
	
		/*
		// Same as above in a square. Not using it any more but gonna leave it here just in case.
		if (Input.mousePosition.y < (((100f-m_HandlerMovement.Deadzone) / 200f) * Screen.height))
		{
			//Debug.Log("down");
			return -1f;
		}
		else if (Input.mousePosition.y > ((((100f-m_HandlerMovement.Deadzone) / 200f)) + (m_HandlerMovement.Deadzone/100f)) * Screen.height)
		{
			//Debug.Log("down");
			return 1f;		
		}	
		else 
		{
			//Debug.Log("neutral");
			return 0f;	
		}
		*/
	}
	
	float GetXAxis()
	{
		if (Mathf.Pow(Input.mousePosition.x - (Screen.width/2f), 2f) > Mathf.Pow(m_HandlerMovement.Deadzone, 2f))
		{
			if (Input.mousePosition.x < Screen.width / 2 )
			{
				Debug.Log("Left");
				return -1f;
			}
			else
			{
				Debug.Log("Right");
				return 1f;
			}
		}
		else 
		{
			Debug.Log("neutral");	
			return 0f;
		}
	}
	void RotateShip()
	{
		m_HandlerMovement.HandleMouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
	}
}
