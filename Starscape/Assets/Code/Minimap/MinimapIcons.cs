using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class MinimapIcons : MonoBehaviour 
{
	public string ImageName;
	public string[] TagsToFind;
    public float[] MaximumDistances;
    public Color[] ColorsOfPointers;

    public Image Pointer;
    public float Speed;

	private List<GameObject> m_Objects;
    private Dictionary<GameObject, GameObject> m_Pointers;
	private GameObject m_Player;

    private Camera m_Camera;
    private Transform m_Canvas;
    private Plane[] m_Planes;

    private const float m_MinDim = 0.05f;
    private const float m_MaxDim = 0.95f;
    private const float m_ZDim = 5f;
	
	void Start () 
	{
        m_Pointers = new Dictionary<GameObject, GameObject>();

        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_Canvas = transform.FindChild("MinimapCanvas");
        m_Camera = GetComponent<Camera>();

		FindObjects();
    }

	void Update () 
	{
		foreach (GameObject obj in m_Objects) 
		{
			if(CheckPointer(obj))
				CreatePointer(obj);
			else
				DestroyPointer(obj);
		}


        foreach (KeyValuePair<GameObject, GameObject> con in m_Pointers)
        {
            con.Value.transform.position = Vector3.MoveTowards(con.Value.transform.position, GetLocation(con.Key.transform.position), Speed * Time.deltaTime);
            Vector3 dir = new Vector3(con.Key.transform.position.x, -400, con.Key.transform.position.z);
            con.Value.transform.LookAt(dir);
        }
    }

	private void FindObjects()
	{
		m_Objects = new List<GameObject>();

		foreach (string tag in TagsToFind) 
		{
			GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
			foreach (GameObject obj in objects) 
			{
				m_Objects.Add(obj);
			}
		}
	}

	private bool CheckPointer(GameObject obj)
	{
        Vector3 playerLocation = m_Player.transform.position;
		float distance = Vector3.Distance(obj.transform.position, playerLocation);
        int index = Array.IndexOf(TagsToFind, obj.tag);
        m_Planes = GeometryUtility.CalculateFrustumPlanes(m_Camera);
        if (GeometryUtility.TestPlanesAABB(m_Planes, obj.GetComponent<MeshRenderer>().bounds))
            return false;
        else if (distance > MaximumDistances[index])
            return false;
        else
            return true;
	}

	private void CreatePointer(GameObject obj)
	{
        if (!m_Pointers.ContainsKey(obj))
        {
            GameObject pointer = ObjectPooler.Current.GetPooledObject();
            pointer.transform.position = GetLocation(obj.transform.position); 
            pointer.transform.rotation = transform.rotation; 
            pointer.transform.SetParent(m_Canvas);
            pointer.SetActive(true);
            int index = Array.IndexOf(TagsToFind, obj.tag);
            pointer.GetComponent<Image>().color = ColorsOfPointers[index];
            m_Pointers.Add(obj, pointer);
        }   
	}

    private Vector3 GetLocation(Vector3 objLoc)
    {
        Vector3 botLeftCam = m_Camera.ViewportToWorldPoint(new Vector3(m_MinDim, m_MinDim, m_Camera.nearClipPlane));
        Vector3 topRightCam = m_Camera.ViewportToWorldPoint(new Vector3(m_MaxDim, m_MaxDim, m_Camera.nearClipPlane));
        Vector3 location = new Vector3();

        if (CheckBetween(objLoc.x, botLeftCam.x, topRightCam.x))
        {
            if (objLoc.z < botLeftCam.z)
                location = new Vector3(m_Camera.WorldToViewportPoint(objLoc).x, m_MinDim, m_ZDim);
            if (objLoc.z > topRightCam.z)
                location = new Vector3(m_Camera.WorldToViewportPoint(objLoc).x, m_MaxDim, m_ZDim);
        }

        else if (CheckBetween(objLoc.z, botLeftCam.z, topRightCam.z))
        {
            if (objLoc.x < botLeftCam.x)
                location = new Vector3(m_MinDim, m_Camera.WorldToViewportPoint(objLoc).y, m_ZDim);
            if (objLoc.x > botLeftCam.x)
                location = new Vector3(m_MaxDim, m_Camera.WorldToViewportPoint(objLoc).y, m_ZDim);
        }

        else
            location = GetDiagonalLocation(objLoc, botLeftCam, topRightCam);

        return m_Camera.ViewportToWorldPoint(location);
    }

    private Vector3 GetDiagonalLocation(Vector3 objLoc, Vector3 botCam, Vector3 topCam)
    {
        Vector3 location = new Vector3(m_MaxDim, m_MaxDim, m_ZDim);

        if(objLoc.z < botCam.z && objLoc.x < botCam.x)
           location = new Vector3(m_MinDim, m_MinDim, m_ZDim);
        if (objLoc.z > botCam.z && objLoc.x < botCam.x)
           location = new Vector3(m_MinDim, m_MaxDim, m_ZDim);
        if (objLoc.z < topCam.z && objLoc.x > topCam.x)
           location = new Vector3(m_MaxDim, m_MinDim, m_ZDim);
       
        return location;
    }

    private bool CheckBetween(float one, float two, float three)
    {
        if (one > two && one < three)
            return true;
        else
            return false;
    }

    private void DestroyPointer(GameObject obj)
	{
        if (m_Pointers.ContainsKey(obj))
        { 
            m_Pointers[obj].SetActive(false);
            m_Pointers.Remove(obj);
        }
    }
}
