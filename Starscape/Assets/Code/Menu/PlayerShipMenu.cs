using UnityEngine;
using System.Collections;

public class PlayerShipMenu : MonoBehaviour
{
	public float Speed;
	
	void Update()
	{
		transform.Translate(Vector3.forward * Time.deltaTime);
	}
}
