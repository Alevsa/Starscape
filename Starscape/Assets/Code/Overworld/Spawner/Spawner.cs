using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	private GameObject m_Player;
	public float Range;
	public bool Active = false;
	// Chance is in percent per frame, might change this to per second at some point or change it to check every ten seconds.
	public float SpawnChance = 0.0001f;
	public float SpawnDistance = 120f;
	public int MaxEnemies = 4;
	public GameObject[] Enemies; 
	
	void Start()
	{
		m_Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
	{
		if (Random.value < SpawnChance*Time.deltaTime && gameObject.transform.childCount < MaxEnemies && Active)
		{
			Spawn();
		}
	}
	
	void Spawn()
	{
		float angle = Random.Range(0, 360);
		float x = SpawnDistance*Mathf.Sin(angle);
		float z = SpawnDistance*Mathf.Cos(angle);
		Vector3 spawnPosition = m_Player.transform.position + new Vector3(x, 0, z);
		GameObject obj = ObjectPooler.Current.GetPooledObject(1);
		obj.transform.parent = gameObject.transform;
        obj.transform.position = spawnPosition;
        obj.transform.rotation = gameObject.transform.rotation;
        obj.SetActive(true);
	}
}
