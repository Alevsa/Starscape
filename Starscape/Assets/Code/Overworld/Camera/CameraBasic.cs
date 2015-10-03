using UnityEngine;
using System.Collections;

public class CameraBasic : MonoBehaviour 
{
	public GameObject focus;
	public float zoom = 50f;
	
	void Start () 
	{
		focus = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
	{
		transform.position = new Vector3(focus.transform.position.x, zoom, focus.transform.position.z);
	}
}
