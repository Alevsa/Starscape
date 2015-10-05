using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	private GameObject player;
	public float range;
	public bool active = false;
	// Chance is in percent per frame, might change this to per second at some point or change it to check every ten seconds.
	public float spawnChance = 0.0001f;
	public float spawnDistance = 20f;
	public int maxEnemies = 4;
	public GameObject[] enemies; 
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
	{
		if (Random.value < spawnChance && gameObject.transform.childCount < maxEnemies && active)
		{
			spawn();
		}
	}
	
	void spawn()
	{
		float angle = Random.Range(0, 360);
		float x = spawnDistance*Mathf.Sin(angle);
		float z = spawnDistance*Mathf.Cos(angle);
		Vector3 spawnPosition = player.transform.position + new Vector3(x, 0, z);
		GameObject obj = (GameObject)Instantiate(enemies[0], spawnPosition, Quaternion.identity);
		obj.transform.parent = gameObject.transform;
	}
}
