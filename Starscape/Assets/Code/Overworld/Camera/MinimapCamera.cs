using UnityEngine;
using System.Collections;

public class MinimapCamera : MonoBehaviour 
{
	private GameObject m_Player;

	void Start()
	{
		m_Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
	{
		transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, m_Player.transform.position.z);
	}
}
