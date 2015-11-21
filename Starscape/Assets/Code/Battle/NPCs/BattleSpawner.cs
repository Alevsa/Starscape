using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BattleSpawner : MonoBehaviour
{
    // Protip when setting variables. Make the chance to spawn add to an easily interpreted number, like 100 or 1.
    // The spawn is ultimately a ratio so if you have your probabilities adding up to something strange like 232 it'll
    // Still work it just wont be as human readable.
    // If there are too many chances to spawn then the later values will be cut off. 

    public List<GameObject> ThingsWhatSpawn;
    public List<float> ChanceToSpawn;
    
    // Dictionaries don't appear in the editor so sadly we have to use two lists.
    private Dictionary<GameObject, float> m_Spawns;
    public int MaxEnemies = 10;
    public Transform[] SpawnLocations;
    public float MeanTimeToSpawn = 60f;
    private float m_TotalProbability;
    // The spawner cooldown is a really shitty solution to the random problem. Because random isn't very
    // random units have a tendency to spawn together, and if they spawn directly on top of eachother 
    // we have a problem. So instead there's a short cooldown on the Spawn.
    public float SpawnCooldown = 1f;
    private float m_SpawnCooldown;
    public List<GameObject> m_EnemiesInScene;

    void Start()
    {
        m_Spawns = new Dictionary<GameObject, float>();
        m_EnemiesInScene = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        for (int i = 0; i < ThingsWhatSpawn.Count; i++)
        {
            m_Spawns.Add(ThingsWhatSpawn[i], ChanceToSpawn[i]);
        }
        foreach (KeyValuePair<GameObject, float> x in m_Spawns)
        { 
            m_TotalProbability += x.Value;
        }

    }

    void Update()
    {
        //Debug.Log(m_EnemiesInScene.Count);
        if (m_EnemiesInScene.Count < MaxEnemies && m_SpawnCooldown < 0f)
        {
            ThinkAboutSpawning();
        }
        m_SpawnCooldown -= Time.deltaTime;
    }

    void ThinkAboutSpawning()
    {
        float temp = Random.value;
        if ((Time.deltaTime / MeanTimeToSpawn) > temp)
        {
            temp = Random.value * m_TotalProbability;
            float x = 0f;
            foreach (KeyValuePair<GameObject, float> obj in m_Spawns)
            {
                if (obj.Value + x > temp)
                {
                    Spawn(obj.Key);
                    break;
                }
                else
                {
                    x += obj.Value;
                }
            }
        }
    }

    void Spawn(GameObject ship)
    {
        m_SpawnCooldown = SpawnCooldown;
        int temp = Random.Range(0, SpawnLocations.Length);
        GameObject newEnemy = GameObject.Instantiate(ship, SpawnLocations[temp].position, SpawnLocations[temp].rotation) as GameObject;
        m_EnemiesInScene.Add(newEnemy);
    }
}
