using UnityEngine;
using System.Collections;

public class OverworldController : MonoBehaviour 
{
	//Ship to be controlled
	public GameObject player;
	private OverworldMovement handlerMovement;
	
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
		handlerMovement.accelerationHandler(Input.GetAxisRaw("Accelerate"));
	}

}
