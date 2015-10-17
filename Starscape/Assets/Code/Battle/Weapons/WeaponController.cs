using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    public Weapon m_EquippedPrimaryWeapon;
    public Weapon m_EquippedSecondaryWeapon;

    public void FirePrimaryWeapon()
    {
        m_EquippedPrimaryWeapon.Fire();
    }

    public void FireSecondaryWeapon()
    {
        m_EquippedSecondaryWeapon.Fire();
    }

    public void EquipPrimaryWeapon(Weapon weap)
    {
        m_EquippedPrimaryWeapon = weap;
    }

    public void EquipSecondaryWeapon(Weapon weap)
    {
        m_EquippedSecondaryWeapon = weap;
    }
}
