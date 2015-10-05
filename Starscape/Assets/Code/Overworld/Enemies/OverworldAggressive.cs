using UnityEngine;
using System.Collections;

public class OverworldAggressive : MonoBehaviour 
{
	// THINGS TO DO:
	//
	// Fade in
	
	#region Variables
	private GameObject focus;
	private GameObject player;
	private GameObject pointer;
	public float turnRate = 0.7f;
	public float maxSpeed = 10f;
	private float speed = 0f;
	public float visionRange = 20f;
	public float acceleration = 0.1f;
	public float despawnRange = 150f;
	private int excluding;
	private Rigidbody body;
	private bool inPursuit = false;
	
	// For the routefinder
	private GameObject[] waypoints;
	private int[] visited;
	private bool bored = true;
	#endregion
	
	#region Start method
	void Start () 
	{
		// This happens as the enemy will need to find the player when it spawns rather than having it preassigned in the inspector.
		// In the same vein will have to have the pointer assigned this way.
		player = GameObject.FindGameObjectWithTag("Player");
		#region Get pointer
		for (int i = 0; i<transform.childCount; i++)
		{	
			GameObject obj = transform.GetChild(i).gameObject;
			if (obj.tag == "Pointer")
			{
				pointer = obj;
			}
		}
		#endregion
		// for the routefinder
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		visited = new int[waypoints.Length];
		for (int i = 0; i < visited.Length; i++)
		{
			visited[i] = 1;
		}
		excluding = waypoints.Length;
		//fadeIn();
	}
	#endregion
	
	#region Update
	void Update () 
	{	
		despawnCheck();
		
		if (inPursuit)
		{
			bored = true;
		}
		if (iCanSeePlayer())
		{
			bored = false;
			inPursuit = true;
			focus = player;
			StopCoroutine("moveToWaypoint");
			moveToFocus();
		}
		
		else if (bored)
		{
			idle();
		}
		
	}
	#endregion
	
	#region Move toward focus/waypoint
	void moveToFocus()
	{
		#region Accelerates
		if (speed < maxSpeed)
		{
			speed += acceleration;
		}
		#endregion
		#region Rotates the enemy to face the player
		pointer.transform.LookAt(focus.transform);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, pointer.transform.rotation, turnRate);
		gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		#endregion
	}
	
	
	public IEnumerator moveToWaypoint()
	{
		while (true)
		{
			moveToFocus();
			yield return null;
		}
	}
	#endregion
	
	#region Handles arriving at waypoints
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Waypoint")
		{
			StopCoroutine("moveToWaypoint");
			bored = true;
		}
	}
	#endregion
	
	#region Idle behavior, patrols the ship around
	void idle()
	{
		focus = returnNearestValidWaypoint(gameObject);
		bored = false;
		StartCoroutine("moveToWaypoint");
	}
	#endregion
	
	#region Sees if the player is in range
	// It's not based on a cone or anything because generally people on ships will look in all directions, Though it would make
	// sense to implement a cone for a sea (space) monster enemy idea I had. More on that later though. 
	bool iCanSeePlayer()
	{
		if (Vector3.Magnitude(player.transform.position - gameObject.transform.position) <= visionRange)
		{
			return true;
		}
		else 
		{
			inPursuit = false;
			return false;
		}
	}
	#endregion
	
	#region Finds next waypoint
	// Here it looks at hte nearest waypoints, it wont go back to the same waypoint twice in a row, and each time a waypoint is selected
	// it gets weighted more heavily so that the enemy doesnt patrol between the same two waypoints forever.
	public GameObject returnNearestValidWaypoint(GameObject origin)
	{
		float[] waypointDistance = new float[waypoints.Length];
		for (int i = 0; i < waypoints.Length; i++) 
		{
			waypointDistance[i] = Vector3.Magnitude(origin.transform.position - waypoints[i].transform.position)*visited[i];
		}
		int minIndex = 0;
		float minDistance = Mathf.Infinity;
		for (int i = 0; i<waypointDistance.Length; i++)
		{
			if (waypointDistance[i] < minDistance && i != excluding)
			{
				minDistance = waypointDistance[i];
				minIndex = i;
			}
		}
		excluding = minIndex;
		visited[minIndex] += 2;
		return waypoints[minIndex];
		
	}
	#endregion
	
	
	IEnumerable fadeIn()
	{
		for (float i = 0; i<3f; i+=Time.deltaTime)
		{
			yield return null;		
		}
	}
	
	void despawnCheck()
	{
		if (Vector3.Distance(player.transform.position, transform.position) > despawnRange)
		{
			
			Destroy(gameObject);
		}
	}
}
