using UnityEngine;
using System.Collections;

public class PlayerShipMenu : MonoBehaviour
{
	public float Speed;
	public float TimeToReveal = 70f;
	void Start()
	{
		transform.Translate(Speed * Vector3.back * TimeToReveal);
	}
	
	void Update()
	{
		transform.Translate(Speed *Vector3.forward * Time.deltaTime);
	}
}
