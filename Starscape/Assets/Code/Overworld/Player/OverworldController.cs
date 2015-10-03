using UnityEngine;
using System.Collections;

public class OverworldController : MonoBehaviour 
{
	//Ship to be controlled
	public GameObject player;
	private OverworldMovement handlerMovement;
	private bool moveInUse = false;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		handlerMovement = player.GetComponent<OverworldMovement>();
	}
	
	void Update () 
	{
		InGameInput ();
	}
	
	//In-game handling
	void InGameInput() 
	{
		handlerMovement.turn(Input.GetAxisRaw("Turn"));
		
		#region Acceleration that only triggers on button press
		if (Input.GetAxisRaw("Accelerate") != 0)
		{
			if(moveInUse == false)
			{
				handlerMovement.accelerationHandler(Input.GetAxisRaw("Accelerate"));
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
