using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Current;
    public GameObject PooledObject;
    public int PooledAmount;
    public bool WillGrow = true;

    private List<GameObject> m_PooledObjects;

    void Awake()
    {
        Current = this;
    }

	void Start ()
    {
        m_PooledObjects = new List<GameObject>();
        for (int i = 0; i < PooledAmount; i++)
        {
            GameObject obj = Instantiate(PooledObject) as GameObject;
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            m_PooledObjects.Add(obj);
        }
	}
	
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < m_PooledObjects.Count; i++)
        {
            if (!m_PooledObjects[i].activeInHierarchy)
                return m_PooledObjects[i];
        }

        if(WillGrow)
        {
            GameObject obj = Instantiate(PooledObject) as GameObject;
            m_PooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}
