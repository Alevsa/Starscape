using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float Speed;

    private Transform m_Direction;
    private float m_NewSpeed;

    void OnEnable()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerBattle");
        m_NewSpeed  = player.GetComponent<ShipCore>().Speed + Speed;
        m_Direction = player.transform;
        transform.Rotate(new Vector3(90, 0, 0));
    }

	void Update ()
    {
        MoveForward();
        Invoke("Destroy", 2f);
	}

    protected virtual void MoveForward()
    {
        transform.position += m_Direction.forward * m_NewSpeed * Time.deltaTime;
    }

    protected virtual void Destroy()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }
}
