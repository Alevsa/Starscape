using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float Speed;

	void Update ()
    {
        MoveForward();
        Invoke("Destroy", 2f);
	}

    protected virtual void MoveForward()
    {
        transform.position += Vector3.forward * Speed * Time.deltaTime;
    }

    protected virtual void Destroy()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }
}
