using UnityEngine;
using System.Collections;

public class TerrainController : MonoBehaviour
{
    public Transform Player;
    public float DrawDistance = 2000f;

    void Update()
    {
        CheckTerrain();
    }

    void CheckTerrain()
    {
        foreach (Transform terrain in transform)
        {
            if (Vector3.Distance(terrain.position, Player.position) > DrawDistance)
            {
                terrain.gameObject.SetActive(false);
            }
            else
            {
                terrain.gameObject.SetActive(true);
            }
        }
    }
    
}
