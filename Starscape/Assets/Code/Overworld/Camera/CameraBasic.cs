using UnityEngine;
using System.Collections;

public class CameraBasic : MonoBehaviour 
{
	public GameObject Focus;
	public float Zoom = 50f;

	void Update () 
	{
		transform.position = new Vector3(Focus.transform.position.x, Zoom, Focus.transform.position.z);
	}
}
