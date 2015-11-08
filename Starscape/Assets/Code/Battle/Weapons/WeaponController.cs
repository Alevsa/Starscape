using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour
{
	[HideInInspector]public bool Alive = true;
	private AudioController m_AudioController; 
	public AudioClip FireSound;
    public string WeapMountName;
    public GameObject EquippedPrimaryWeapon;
    public GameObject EquippedSecondaryWeapon;

    private Weapon m_PrimWeap;
    private Weapon m_SecWeap;

    private List<Transform> m_FiringPoints;

    public void Start()
    {
    	m_AudioController = gameObject.GetComponent<AudioController>();
        m_FiringPoints = new List<Transform>();
        foreach (Transform tran in transform)
            if (tran.gameObject.name.Contains(WeapMountName))
                m_FiringPoints.Add(tran);

        if (EquippedPrimaryWeapon != null)
            EquipPrimaryWeapon(EquippedPrimaryWeapon);
        if (EquippedSecondaryWeapon != null)
            EquipSecondaryWeapon(EquippedSecondaryWeapon);
    }

    public void FirePrimaryWeaponTap()
    {
        FirePrimWeap();
    }

    public void FirePrimaryWeaponHold()
    {
        if (m_PrimWeap.CanFire())
        {
            FirePrimWeap();
        }
    }

    private void FirePrimWeap()
    {
        if (Alive)
        {
            if (FireSound != null)
            {
                m_AudioController.PlaySound(FireSound);
                m_PrimWeap.Fire(m_FiringPoints);
            }
        }
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
        m_PrimWeap.SetParams(gameObject);
    }

    public void EquipSecondaryWeapon(GameObject weap)
    {
        GameObject weapon = Instantiate(weap, transform.position, transform.rotation) as GameObject;
        weapon.transform.SetParent(transform);
        EquippedSecondaryWeapon = weapon;
        m_SecWeap = weapon.GetComponent<Weapon>();
        m_SecWeap.SetParams(gameObject);
    }
}
