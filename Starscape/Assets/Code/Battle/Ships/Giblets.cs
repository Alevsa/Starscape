using UnityEngine;
using System.Collections;

public class Giblets : MonoBehaviour 
{
	private Vector3 m_EulerSpin;
	private Quaternion m_Spin;
	private Vector3 m_Velocity;
	private Rigidbody m_Body;
	public float Force = 10f;
	
	void Start () 
	{
		m_Body = gameObject.GetComponent<Rigidbody>();
		m_EulerSpin = new Vector3(Random.value * Force, Random.value * Force, Random.value * Force);
		m_Spin = Quaternion.Euler(m_EulerSpin);
		m_Velocity = new Vector3(Random.value * Force, Random.value * Force, Random.value * Force);
	}
	
	void FixedUpdate () 
	{
		m_Body.AddForce(m_Velocity);
		transform.Rotate(m_EulerSpin);
	}
}
