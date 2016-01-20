using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour
{
    private GameObject[] m_Terrain;

    void Start()
    {
        m_Terrain = new GameObject[9];
    }

    void Update()
    {
        SetActiveTerrainBlocks();
    }

    void SetActiveTerrainBlocks()
    {
    }

    void GenerateNewTerrainBlock()
    {
    }

}
