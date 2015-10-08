using UnityEngine;
using System.Collections;

public class OverworldStats : MonoBehaviour 
{
	public float TurnRate = 50f;
	public float Acceleration = 0.25f;
	public float WarpSpeed = 40f;
	public float ImpulsePower = 1f;
	public float WarpChargeTime = 5f;
	public float WarpTurnRate = 1f;
	[HideInInspector] public float Speed = 0f;
}
