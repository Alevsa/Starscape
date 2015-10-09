using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinimapIcons : MonoBehaviour 
{
	public string ImageName;
	public string[] TagsToFind;
	public float IconDimensions;
	public float MaximumDistance;

	private List<GameObject> m_Objects;
	private List<GameObject> m_Icons;

	private GameObject m_Player;
	
	void Start () 
	{
		m_Player = GameObject.FindGameObjectWithTag("Player");
		FindObjects();
		DetermineIcons ();
	}

	void Update () 
	{
		foreach (GameObject obj in m_Objects) 
		{
			if(CheckDistance(obj.transform.position))
				DisplayIcon(obj);
			else
				DestroyIcon(obj);
		}
	}

	private void FindObjects()
	{
		m_Objects = new List<GameObject>();

		foreach (string tag in TagsToFind) 
		{
			GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
			foreach (GameObject obj in objects) 
			{
				m_Objects.Add(obj);
			}
		}
	}

	private void DetermineIcons()
	{
		m_Icons = new List<GameObject>();

		foreach (GameObject obj in m_Objects) 
		{
			GameObject icon = obj.transform.Find(ImageName).gameObject;
			icon.transform.localScale = new Vector3(IconDimensions, IconDimensions);
			m_Icons.Add (icon);
		}
	}

	private bool CheckDistance(Vector3 objLocation)
	{
		Vector3 playerLocation = m_Player.transform.position;
		float distance = Vector3.Distance(objLocation, playerLocation);
		if(distance < MaximumDistance)
			return true;
		else
			return false;
	}

	private void DisplayIcon(GameObject obj)
	{
	}

	private void DetermineIconPosition()
	{
	}

	private void DestroyIcon(GameObject obj)
	{
	}

}
