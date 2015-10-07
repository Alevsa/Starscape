using UnityEngine;
using System.Collections;

public class OverworldCamera : MonoBehaviour 
{
	private GameObject focus;
	public float zoomFactor = 1f;
	public float zoomTime = 5f;
	private float zoomMinimum = 1f;
	private OverworldStats stats = null;
	private float v = 0f;
	
	void Start () 
	{
		focus = GameObject.FindGameObjectWithTag("Player");
		stats = focus.GetComponent<OverworldStats>();
		zoomMinimum = stats.impulsePower * zoomFactor;
	}
	
	void Update () 
	{
		float zoom = getZoom();
		zoom = Mathf.SmoothDamp(transform.position.y, zoom, ref v, zoomTime);
		transform.position = new Vector3(focus.transform.position.x, zoom, focus.transform.position.z);
	}
	
	float getZoom()
	{
		float zoom = stats.speed * zoomFactor;
		if (zoom > zoomMinimum)
		{
			return zoom;
		}
		else 
		{
			return zoomMinimum;
		}
	}
}
