using UnityEngine;
using System.Collections;

public class Giblets : MonoBehaviour 
{
	private Vector3 m_Spin;
	private Vector3 m_Velocity;
	private Rigidbody m_Body;
	public float Force = 10000f;
    public float MinTimeTillDestroy;
    public float MaxTimeTillDestroy;
    public int PoolExplosionIndex;
	
	void OnEnable () 
	{
		m_Body = gameObject.GetComponent<Rigidbody>();
        m_Spin = Random.rotation.eulerAngles;

        transform.rotation = Random.rotation;
        m_Velocity = Random.rotation * transform.forward * Force;

        float time = Random.Range(MinTimeTillDestroy, MaxTimeTillDestroy);
        Invoke("Destroy", time);
	}
	
	void FixedUpdate () 
	{
		m_Body.AddForce(m_Velocity);
		transform.Rotate(m_Spin*Force);
	}

    private void Destroy()
    {
        CancelInvoke();
        GameObject explosion = ObjectPooler.Current.GetPooledObject(PoolExplosionIndex);
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
        explosion.SetActive(true);
        gameObject.SetActive(false);
    }
}
