using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Current;
    public List<GameObject> PooledObjects;
    public List<int> PooledAmounts;
    public bool WillGrow = true;

    private List<List<GameObject>> m_PooledObjects;

    void Awake()
    {
        Current = this;
    }

	void Start ()
    {
        m_PooledObjects = new List<List<GameObject>>();

        for (int i = 0; i < PooledObjects.Count; i++)
        {
            m_PooledObjects.Add(new List<GameObject>());
            for (int j = 0; j < PooledAmounts[i]; j++)
            {
                GameObject obj = Instantiate(PooledObjects[i]) as GameObject;
                obj.transform.SetParent(transform);
                obj.SetActive(false);
                m_PooledObjects[i].Add(obj);
            }
        }
	}
	
    public GameObject GetPooledObject(int index)
    {
        for (int i = 0; i < m_PooledObjects[index].Count; i++)
        {
            if (!m_PooledObjects[index][i].activeInHierarchy)
                return m_PooledObjects[index][i];
        }

        if(WillGrow)
        {
            GameObject obj = Instantiate(PooledObjects[index]) as GameObject;
            m_PooledObjects[index].Add(obj);
            return obj;
        }

        return null;
    }
}
