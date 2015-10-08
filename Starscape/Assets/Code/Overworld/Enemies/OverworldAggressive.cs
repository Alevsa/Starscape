using UnityEngine;
using System.Collections;

public class OverworldAggressive : MonoBehaviour 
{
	// THINGS TO DO:
	//
	// Fade in
	
	#region Variables
	private GameObject m_Focus;
	private GameObject m_Player;
	private GameObject m_Pointer;
	public float TurnRate = 0.7f;
	public float MaxSpeed = 10f;
	private float m_Speed = 0f;
	public float VisionRange = 20f;
	public float Acceleration = 0.1f;
	public float DespawnRange = 150f;
	private int m_Excluding;
	private Rigidbody m_Body;
	private bool m_InPursuit = false;
	
	// For the routefinder
	private GameObject[] m_Waypoints;
	private int[] m_Visited;
	private bool m_Bored = true;
	#endregion
	
	#region Start method
	void Start () 
	{
		// This happens as the enemy will need to find the m_Player when it spawns rather than having it preassigned in the inspector.
		// In the same vein will have to have the pointer assigned this way.
		m_Player = GameObject.FindGameObjectWithTag("Player");
		#region Get pointer
		for (int i = 0; i<transform.childCount; i++)
		{	
			GameObject obj = transform.GetChild(i).gameObject;
			if (obj.tag == "Pointer")
			{
				m_Pointer = obj;
			}
		}
		#endregion
		// for the routefinder
		m_Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		m_Visited = new int[m_Waypoints.Length];
		for (int i = 0; i < m_Visited.Length; i++)
		{
			m_Visited[i] = 1;
		}
		m_Excluding = m_Waypoints.Length;
		//fadeIn();
	}
	#endregion
	
	#region Update
	void Update () 
	{	
		despawnCheck();
		
		if (m_InPursuit)
		{
			m_Bored = true;
		}
		if (iCanSeePlayer())
		{
			m_Bored = false;
			m_InPursuit = true;
			m_Focus = m_Player;
			StopCoroutine("moveToWaypoint");
			moveToFocus();
		}
		
		else if (m_Bored)
		{
			idle();
		}
		
	}
	#endregion
	
	#region Move toward m_Focus/waypoint
	void moveToFocus()
	{
		#region Accelerates
		if (m_Speed < MaxSpeed)
		{
			m_Speed += Acceleration;
		}
		#endregion
		#region Rotates the enemy to face the m_Player
		m_Pointer.transform.LookAt(m_Focus.transform);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, m_Pointer.transform.rotation, TurnRate);
		gameObject.transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
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
	
	#region Handles arriving at m_Waypoints
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Waypoint")
		{
			StopCoroutine("moveToWaypoint");
			m_Bored = true;
		}
	}
	#endregion
	
	#region Idle behavior, patrols the ship around
	void idle()
	{
		m_Focus = returnNearestValidWaypoint(gameObject);
		m_Bored = false;
		StartCoroutine("moveToWaypoint");
	}
	#endregion
	
	#region Sees if the m_Player is in range
	// It's not based on a cone or anything because generally people on ships will look in all directions, Though it would make
	// sense to implement a cone for a sea (space) monster enemy idea I had. More on that later though. 
	bool iCanSeePlayer()
	{
		if (Vector3.Magnitude(m_Player.transform.position - gameObject.transform.position) <= VisionRange)
		{
			return true;
		}
		else 
		{
			m_InPursuit = false;
			return false;
		}
	}
	#endregion
	
	#region Finds next waypoint
	// Here it looks at hte nearest m_Waypoints, it wont go back to the same waypoint twice in a row, and each time a waypoint is selected
	// it gets weighted more heavily so that the enemy doesnt patrol between the same two m_Waypoints forever.
	public GameObject returnNearestValidWaypoint(GameObject origin)
	{
		float[] waypointDistance = new float[m_Waypoints.Length];
		for (int i = 0; i < m_Waypoints.Length; i++) 
		{
			waypointDistance[i] = Vector3.Magnitude(origin.transform.position - m_Waypoints[i].transform.position)*m_Visited[i];
		}
		int minIndex = 0;
		float minDistance = Mathf.Infinity;
		for (int i = 0; i<waypointDistance.Length; i++)
		{
			if (waypointDistance[i] < minDistance && i != m_Excluding)
			{
				minDistance = waypointDistance[i];
				minIndex = i;
			}
		}
		m_Excluding = minIndex;
		m_Visited[minIndex] += 2;
		return m_Waypoints[minIndex];
		
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
		if (Vector3.Distance(m_Player.transform.position, transform.position) > DespawnRange)
		{
			
			Destroy(gameObject);
		}
	}
}
