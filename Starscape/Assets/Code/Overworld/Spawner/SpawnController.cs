using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour 
{
	private List<GameObject> m_Spawners;
	private int m_ActiveSpawnerIndex;
	public GameObject DefaultSpawner;
	public GameObject Player;
	public float CheckInterval = 10f;
	private float m_Timer = 0f;
	
	void Start()
	{
		m_Spawners = new List<GameObject>();
		Player = GameObject.FindGameObjectWithTag("Player");
		DefaultSpawner = GameObject.FindGameObjectWithTag("DefaultSpawner");
		GameObject[] temp = GameObject.FindGameObjectsWithTag("Spawner"); 
		foreach (GameObject tmp in temp)
		{
			m_Spawners.Add(tmp);
		}
		m_Spawners.Add(DefaultSpawner);
		DisableAllSpawners();
		StartCoroutine("CheckSpawners");
	}
	
	//coroutine that changes the active spawner every ~ten seconds
	private IEnumerator CheckSpawners()
	{
		while (true)
		{
			m_Timer += Time.deltaTime;
			if (m_Timer > CheckInterval)
			{
				DisableAllSpawners();
				ActivateSpawner();
				m_Timer = 0f;
			}
			yield return null;
		}
	}

	private void DisableAllSpawners()
	{
		foreach (GameObject spawner in m_Spawners)
		{
			spawner.GetComponent<Spawner>().Active = false;
		}
	}
	
	// Returns the index of the spawner that should be active.
	private void ActivateSpawner()
	{
		for (int i = 0; i < m_Spawners.Count - 1; i++)
		{
			if (Vector3.Distance(Player.transform.position, m_Spawners[i].transform.position) < m_Spawners[i].GetComponent<Spawner>().Range)
			{
				m_Spawners[i].GetComponent<Spawner>().Active = true;
				break;
			}
		}
		m_Spawners[m_Spawners.Count-1].GetComponent<Spawner>().Active = true;
	}
}
