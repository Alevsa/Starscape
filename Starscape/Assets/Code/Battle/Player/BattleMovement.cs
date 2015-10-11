using UnityEngine;
using System.Collections;

public class BattleMovement : MonoBehaviour 
{
	private ShipCore m_Stats;
	private Rigidbody m_Body;
	private float m_Speed;
	public GameObject Gyroscope;
	public float RightingRate = 1f;
	public float ConstrainedAngle = 30f;
	public float ConstrainingThreshold = 0.7f;
	
	void Start()
	{	
		for (int i = 0; i<transform.childCount; i++)
		{	
			GameObject obj = transform.GetChild(i).gameObject;
			if (obj.tag == "Pointer")
			{
				Gyroscope = obj;
			}
		}
		m_Stats = GetComponent<ShipCore> ();
		m_Body = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate()
	{	
		MaintainLevel();
		Movement();
	}

	void MaintainLevel()
	{
		Gyroscope.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
	}
	
	void Movement()
	{
		m_Body.AddRelativeForce(Vector3.forward * m_Speed * Time.fixedDeltaTime);
	}
	
	public void Accelerate()
	{
		if (m_Speed < m_Stats.MaxSpeed)
		{
			m_Speed += m_Stats.Acceleration*Time.deltaTime;
		}
	}
	
	public void Decelerate()
	{
		if (m_Speed > 0f)
		{
			m_Speed -= m_Stats.Deceleration*Time.deltaTime;
		}
	} 
	
	public void ConstrainedRotation(float magnitude)
	{
		if (Mathf.Abs(transform.rotation.eulerAngles.x) < ConstrainedAngle)
		{
			transform.Rotate( m_Stats.TurnRate * magnitude * Time.deltaTime, 0f, 0f );
		}
	}
	
	public void HandleMouse(float x, float y)
	{	 
		if (x == 0f && y == 0f)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Gyroscope.transform.rotation, RightingRate);
		}
		
		if (Mathf.Abs(y) < ConstrainingThreshold )
		{
			ConstrainedRotation(y);
		}
		else 
		{
			transform.Rotate( m_Stats.TurnRate * y * Time.deltaTime, 0f, 0f );
		}
		transform.Rotate( 0f,  m_Stats.TurnRate * x *Time.deltaTime, 0f );
	}
}
