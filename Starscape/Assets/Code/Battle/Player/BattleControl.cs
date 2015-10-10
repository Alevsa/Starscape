using UnityEngine;
using System.Collections;

public class BattleControl : MonoBehaviour 
{	
	//Ship to be controlled
	public GameObject Ship;
	private BattleMovement m_HandlerMovement;
	private float m_RotDamping;
	
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
		Debug.Log(Input.mousePosition);
		m_HandlerMovement.HandleMouse(GetXAxis(), GetYAxis());		
	}
	
	float GetYAxis()
	{
		if (Input.mousePosition.y < (((100f-m_HandlerMovement.Deadzone) / 200f) * Screen.height))
		{
			//Debug.Log("up");
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
	}
	
	float GetXAxis()
	{
		if (Input.mousePosition.x < (((100f-m_HandlerMovement.Deadzone) / 200f) * Screen.width))
		{
			//Debug.Log("left");
			return -1f;
		}
		else if (Input.mousePosition.x > ((((100f-m_HandlerMovement.Deadzone) / 200f)) + (m_HandlerMovement.Deadzone/100f)) * Screen.width)
		{
			//Debug.Log("right");
			return 1f;	
		}
		else 
		{
			//Debug.Log("neutral");
			return 0f;	
		}
	}
	void RotateShip()
	{
		m_HandlerMovement.HandleMouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
	}
}
