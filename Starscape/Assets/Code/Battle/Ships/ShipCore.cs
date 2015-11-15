using System.Linq;
using System.Collections;
using UnityEngine;

public class ShipCore : ShipComponent
{	
	private ShipPeripheral[] m_ShipPeripherals;
    public ShipPeripheral[] AdditionalPeripherals;
    public float DeathTime = 0f;

	protected override void Start () 
	{
		base.Start();
        m_ShipPeripherals = GetComponentsInChildren<ShipPeripheral>();
        m_ShipPeripherals.Concat(AdditionalPeripherals);

        Alive = true;
		foreach(ShipPeripheral peripheral in m_ShipPeripherals)
		{
			TurnRate += peripheral.TurnRate;
			Acceleration += peripheral.Acceleration;
			Deceleration += peripheral.Deceleration;
			MaxSpeed += peripheral.MaxSpeed;
			MaxHealth += peripheral.MaxHealth;
            Health += peripheral.MaxHealth;
            MaxReverseSpeed += peripheral.MaxReverseSpeed;
			RollRate += peripheral.RollRate;
		}
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
        float[] peripheralDeathTime = new float[m_ShipPeripherals.Length];
        for (int i = 0; i < m_ShipPeripherals.Length; i++)
        {
            peripheralDeathTime[i] = Random.Range(0, DeathTime);
            yield return null;
        }
        for (float i = DeathTime; i > 0; i -= Time.deltaTime)
        {
            for (int j = 0; j < m_ShipPeripherals.Length; j++)
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
