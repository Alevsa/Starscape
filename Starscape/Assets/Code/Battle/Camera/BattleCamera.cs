using UnityEngine;
using System.Collections;

public class BattleCamera : MonoBehaviour 
{
	// TO DO: Fix horrible camera jitter, it happens when you're moving. Not sure why yet.
	private Transform m_Focus;
	private ShipCore m_Stats;
	private Vector3 m_DesiredPosition;
	public float Height = 2f;
	public float DampingFactor = 0.1f;
	public float RotationDampingFactor = 1f;
	private float m_RotationDamping;
	private float m_Damping;
	public float ZoomFactor = 0.004f;
	public float CameraOffset = 7f;
	public float DampingOffset = 1f;
	public float RotationDampingOffset = 1f;

	void Start()
	{
		m_Focus = GameObject.FindGameObjectWithTag("PlayerBattle").transform;
		m_Stats = m_Focus.GetComponent<ShipCore>();
	}
	// I'll try and explain what's happening here cause it's probably intimidating for you who didn't write it.
	//
	// The damping is how quickly the camera will get into position. When the ship is moving quickly it needs to move into position more quickly
	// Hence multiplying the damping by the speed. The offset is important because when speed is 0 we don't want the camera to go inside the player's
	// ship. Rotation damping is the same except for rotation, it doesnt depend on speed though instead it depends on turn rate. The desired position is
	// just a position behing hte player that we want the camera to move to, then we do the movetoward method to get there and the rotate toward to 
	// gradually reach the correct position.
	//
	// The various factors, (RotationDampingFactor, DampingFactor etc) all need fine tuning in the inspector so that the rotation is slow enough to allow
	// the player to see the ship rotate (else it feels like the player is controlling the camera rather than the ship) yet fast enough that it's still 
	// playable.
	//
	// Finally the MoveTowards/RotateTowards methods need to get faster the further from the desired position they are, otherwise the player would be able
	// to move/rotate faster than the camera leading to unwanted behavior. This is done by finding the distance between the position/rotation then multiplying
	// it by the damping.
	//
	// enjoy ur wall of text.
	void Update()
	{
		m_Damping = (Mathf.Abs(m_Stats.Speed) * DampingFactor) + DampingOffset;
		m_RotationDamping = Mathf.Abs(m_Stats.TurnRate) + RotationDampingOffset;
		m_DesiredPosition = (-1f) * (m_Focus.forward * ZoomFactor * Mathf.Abs(m_Stats.Speed) + (m_Focus.forward * CameraOffset) + (m_Focus.up * - Height));		
		m_DesiredPosition += m_Focus.position;
		transform.localPosition = Vector3.MoveTowards(transform.position, m_DesiredPosition, m_Damping*Time.deltaTime*Vector3.Distance(transform.position, m_DesiredPosition));
		transform.rotation = Quaternion.RotateTowards(transform.rotation, m_Focus.rotation, m_RotationDamping*Time.deltaTime*Vector3.Distance(transform.rotation.eulerAngles, m_Focus.rotation.eulerAngles));
	}
	
}
