using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour
{
    public int EdgeSize = 100;
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
        Terrain ter = new Terrain();
        Texture2D per = new Texture2D(EdgeSize, EdgeSize);

    }

}
