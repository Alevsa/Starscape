using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour 
{
	private List<GameObject> spawners;
	private int activeSpawnerIndex;
	public GameObject defaultSpawner;
	public GameObject player;
	public float checkInterval = 10f;
	private float timer = 0f;
	
	void Start()
	{
		spawners = new List<GameObject>();
		player = GameObject.FindGameObjectWithTag("Player");
		defaultSpawner = GameObject.FindGameObjectWithTag("DefaultSpawner");
		GameObject[] temp = GameObject.FindGameObjectsWithTag("Spawner"); 
		Debug.Log(temp);
		foreach (GameObject tmp in temp)
		{
			Debug.Log(tmp);
			spawners.Add(tmp);
		}
		Debug.Log(defaultSpawner);
		spawners.Add(defaultSpawner);
		disableAllSpawners();
		StartCoroutine("CheckSpawners");
	}
	
	//coroutine that changes the active spawner every ~ten seconds
	private IEnumerator CheckSpawners()
	{
		while (true)
		{
			timer += Time.deltaTime;
			if (timer > checkInterval)
			{
				disableAllSpawners();
				spawners[returnActiveSpawner()].GetComponent<Spawner>().active = true;
				timer = 0f;
			}
			yield return null;
		}
	}

	private void disableAllSpawners()
	{
		foreach (GameObject spawner in spawners)
		{
			spawner.GetComponent<Spawner>().active = false;
		}
	}
	
	// Returns the index of the spawner that should be active.
	private int returnActiveSpawner()
	{
		// If there's only the default spawner.
		if (spawners.Count == 1)
		{
			return 0;
		}
		for (int i = 0; i < spawners.Count - 2; i++)
		{
			if (Vector3.Distance(player.transform.position, spawners[i].transform.position) < spawners[i].GetComponent<Spawner>().range)
			{
				return i;
			}
		}
		
		return (spawners.Count-1);
	}
}
