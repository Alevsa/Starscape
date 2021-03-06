using UnityEngine;
using System.Collections;

public class OverworldCamera : MonoBehaviour 
{
	private GameObject m_Focus;
	public float ZoomFactor = 3f;
	public float ZoomTime = 5f;
	public float ZoomOffset = 0f;
	private float m_ZoomMinimum = 1f;
	private OverworldStats m_Stats = null;
	private float v = 0f;
	private float m_Zoom;
	
	void Start () 
	{
		m_Focus = GameObject.FindGameObjectWithTag("Player");
		m_Stats = m_Focus.GetComponent<OverworldStats>();
		m_ZoomMinimum = m_Stats.ImpulsePower * ZoomFactor;
		m_Zoom = GetZoom();
		transform.position = new Vector3(m_Focus.transform.position.x, m_Zoom, m_Focus.transform.position.z);
	}
	
	void Update () 
	{
		m_Zoom = GetZoom();
		m_Zoom = Mathf.SmoothDamp(transform.position.y, m_Zoom, ref v, ZoomTime);
		transform.position = new Vector3(m_Focus.transform.position.x, m_Zoom, m_Focus.transform.position.z);
	}
	
	float GetZoom()
	{	
		float m_Zoom = m_Stats.Speed * ZoomFactor;
		if (m_Zoom > m_ZoomMinimum)
		{
			return m_Zoom;
		}
		else 
		{
			return m_ZoomMinimum;
		}
	}
}
