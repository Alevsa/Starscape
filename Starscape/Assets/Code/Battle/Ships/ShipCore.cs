using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCore : ShipComponent
{	
	private List<ShipPeripheral> m_ShipPeripherals;
    public List<ShipPeripheral> AdditionalPeripherals;
    public float DeathTime = 0f;
    public float PeripheralHealthContribution = 0.6f;


	protected override void Start () 
	{
        m_ShipPeripherals = GetComponentsInChildren<ShipPeripheral>().ToList();    
        Alive = true;
		foreach(ShipPeripheral peripheral in m_ShipPeripherals)
		{
			TurnRate += peripheral.TurnRate;
			Acceleration += peripheral.Acceleration;
			Deceleration += peripheral.Deceleration;
			MaxSpeed += peripheral.MaxSpeed;
			MaxHealth += peripheral.MaxHealth * PeripheralHealthContribution;
            MaxReverseSpeed += peripheral.MaxReverseSpeed;
			RollRate += peripheral.RollRate;
		}
        m_ShipPeripherals.AddRange(AdditionalPeripherals);
        base.Start();
    }
	
	void Update()
	{
		if (Health <= 0 && Alive)
			Die ();
	}
	
	void Die()
	{	
		//Debug.Log("Dead");
		WeaponController weapons = gameObject.GetComponent<WeaponController>();
		if (weapons != null)
		{
			weapons.Alive = false;
		}
		Alive = false;
		TurnRate = 0f;
		Acceleration = 0f;
		Deceleration = 0f;
		RollRate = 0f;
        StartCoroutine("PeripheralDeaths");
        //StartCoroutine("DeathAnimation");
    }

    private IEnumerator PeripheralDeaths()
    {
        float[] peripheralDeathTime = new float[m_ShipPeripherals.Count];
        Debug.Log(peripheralDeathTime.Length);
        for (int i = 0; i < m_ShipPeripherals.Count; i++)
        {
            peripheralDeathTime[i] = Random.Range(0, DeathTime);
            yield return null;
        }
        for (float i = DeathTime; i > 0; i -= Time.deltaTime)
        {
            for (int j = 0; j < m_ShipPeripherals.Count; j++)
            {
                if (i < peripheralDeathTime[j])
                {
                    m_ShipPeripherals[j].Health = 0f;
                }
            }
            yield return null;
        }
        DeathAnimation();
    }
}
