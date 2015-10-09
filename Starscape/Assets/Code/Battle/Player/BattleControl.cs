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
		rotateShip();		
	}
	
	void rotateShip()
	{
		m_HandlerMovement.HandleMouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
	}
}
