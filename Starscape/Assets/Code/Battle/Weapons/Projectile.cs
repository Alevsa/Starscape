using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float Speed;

	void Update ()
    {
        MoveForward();
	}

    protected void MoveForward()
    {
        transform.position += Vector3.forward * Speed * Time.deltaTime;
    }
}
