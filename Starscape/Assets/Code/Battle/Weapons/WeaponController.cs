using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour
{
	[HideInInspector]public bool Alive = true;
    public string WeapMountName;
    public GameObject EquippedPrimaryWeapon;
    public GameObject EquippedSecondaryWeapon;

    private Weapon m_PrimWeap;
    private Weapon m_SecWeap;

    private List<Transform> m_FiringPoints;

    public void Start()
    {
        m_FiringPoints = new List<Transform>();
        foreach (Transform tran in transform)
            if (tran.gameObject.name.Contains(WeapMountName))
                m_FiringPoints.Add(tran);

        if (EquippedPrimaryWeapon != null)
            EquipPrimaryWeapon(EquippedPrimaryWeapon);
        if (EquippedSecondaryWeapon != null)
            EquipSecondaryWeapon(EquippedSecondaryWeapon);
    }

    public void FirePrimaryWeapon()
    {
    	if (Alive)
       		m_PrimWeap.Fire(m_FiringPoints);
    }

    public void FireSecondaryWeapon()
    {
    	if (Alive)
        	m_SecWeap.Fire(m_FiringPoints);
    }

    public void EquipPrimaryWeapon(GameObject weap)
    {
        GameObject weapon = Instantiate(weap, transform.position, transform.rotation) as GameObject;
        weapon.transform.SetParent(transform);
        EquippedPrimaryWeapon = weapon;
        m_PrimWeap = weapon.GetComponent<Weapon>();
    }

    public void EquipSecondaryWeapon(GameObject weap)
    {
        GameObject weapon = Instantiate(weap, transform.position, transform.rotation) as GameObject;
        weapon.transform.SetParent(transform);
        EquippedSecondaryWeapon = weapon;
        m_SecWeap = weapon.GetComponent<Weapon>();
    }
}
