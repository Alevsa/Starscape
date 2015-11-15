using UnityEngine;
using System.Collections;

public class Giblets : MonoBehaviour 
{
	private Vector3 m_EulerSpin;
	private Quaternion m_Spin;
	private Vector3 m_Velocity;
	private Rigidbody m_Body;
	public float Force = 1000f;
    public float MinTimeTillDestroy;
    public float MaxTimeTillDestroy;
    public int PoolExplosionIndex;
	
	void OnEnable () 
	{
		m_Body = gameObject.GetComponent<Rigidbody>();
		m_EulerSpin = new Vector3(Random.value * Force , Random.value * Force, Random.value * Force);
		m_Spin = Quaternion.Euler(m_EulerSpin);
		m_Velocity = new Vector3(Random.value * Force, Random.value * Force, Random.value * Force);
        Debug.Log(m_Velocity);
        Debug.Log(m_EulerSpin);

        float time = Random.Range(MinTimeTillDestroy, MaxTimeTillDestroy);
        Invoke("Destroy", time);
	}
	
	void FixedUpdate () 
	{
		m_Body.AddForce(m_Velocity);
		transform.Rotate(m_EulerSpin);
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
