using UnityEngine;
using System.Collections;

public class OverworldController : MonoBehaviour 
{
	//Ship to be controlled
	public GameObject Player;
	private OverworldMovement m_HandlerMovement;
	private bool moveInUse = false;
	
	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		m_HandlerMovement = Player.GetComponent<OverworldMovement>();
	}
	
	void Update () 
	{
		InGameInput ();
	}
	
	//In-game handling
	void InGameInput() 
	{
		m_HandlerMovement.Turn(Input.GetAxisRaw("Turn"));
		
		#region Acceleration that only triggers on button press
		if (Input.GetAxisRaw("Accelerate") != 0)
		{
			if(moveInUse == false)
			{
				m_HandlerMovement.AccelerationHandler(Input.GetAxisRaw("Accelerate"));
				moveInUse = true;
			}
		}
		if( Input.GetAxisRaw("Accelerate") == 0)
		{
			moveInUse = false;
		}  
		#endregion
	}

}
