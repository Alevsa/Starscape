using UnityEngine;
using System.Collections;

public class OverworldController : MonoBehaviour 
{
	//Ship to be controlled
	public GameObject Player;
	private OverworldMovement m_HandlerMovement;
	public PauseMenu PauseMenuController;
	private bool MoveInUse = false;
	
	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		m_HandlerMovement = Player.GetComponent<OverworldMovement>();
		Player.transform.position = SaveLoadController.GetSavedPlayerPosition();
	}
	
	void Update () 
	{
		InGameInput ();
	}
	
	//In-game handling
	void InGameInput() 
	{	
		if (Input.GetAxisRaw("Turn") != 0f)
			m_HandlerMovement.Turn(Input.GetAxisRaw("Turn"));
		else
			m_HandlerMovement.Turn(Input.GetAxis("Horizontal"));
		
		#region Acceleration that only triggers on button press
		if (Input.GetAxisRaw("Accelerate") != 0)
		{
			if(MoveInUse == false)
			{
				m_HandlerMovement.AccelerationHandler(Input.GetAxisRaw("Accelerate"));
				MoveInUse = true;
			}
		}
		if (Input.GetAxisRaw("Accelerate") == 0)
		{
			MoveInUse = false;
		}  
		if (Input.GetButtonDown("Pause"))
			PauseMenuController.TogglePauseMenu();
			
		
		#endregion
	}

}
