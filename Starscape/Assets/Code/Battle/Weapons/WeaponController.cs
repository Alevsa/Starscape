using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour
{
    public GameObject EquippedPrimaryWeapon;
    public GameObject EquippedSecondaryWeapon;

    private GameObject m_Player;
    private Weapon m_PrimWeap;
    private Weapon m_SecWeap;

    private List<Transform> m_FiringPoints;

    public void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("PlayerBattle");
        transform.parent = m_Player.transform;
        transform.position = m_Player.transform.position;

        m_FiringPoints = new List<Transform>();
        foreach (Transform tran in m_Player.transform)
            if (tran.gameObject.name.Contains("FiringPoint"))
                m_FiringPoints.Add(tran);

        if (EquippedPrimaryWeapon != null)
            EquipPrimaryWeapon(EquippedPrimaryWeapon);
        if (EquippedSecondaryWeapon != null)
            EquipSecondaryWeapon(EquippedSecondaryWeapon);
    }

    public void FirePrimaryWeapon()
    {
        m_PrimWeap.Fire(m_FiringPoints);
    }

    public void FireSecondaryWeapon()
    {
        m_SecWeap.Fire(m_FiringPoints);
    }

    public void EquipPrimaryWeapon(GameObject weap)
    {
        GameObject w = Instantiate(weap, transform.position, transform.rotation) as GameObject;
        w.transform.SetParent(transform);
        EquippedPrimaryWeapon = w;
        m_PrimWeap = w.GetComponent<Weapon>();
    }

    public void EquipSecondaryWeapon(GameObject weap)
    {
        GameObject w = Instantiate(weap, transform.position, transform.rotation) as GameObject;
        w.transform.SetParent(transform);
        EquippedSecondaryWeapon = w;
        m_SecWeap = w.GetComponent<Weapon>();
    }
}
