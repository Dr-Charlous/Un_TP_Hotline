using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersWeaponnary : MonoBehaviour
{
    public WeaponsData WeaponData;
    public WeaponsData WeaponDataHand;
    public WeaponsLong WLong;
    public WeaponsShort WShort;
    public bool isEquip = false;

    private void Update()
    {
        if (WeaponData != null && WeaponData != WeaponDataHand)
        {
            isEquip = true;
        }
        else
        {
            WeaponData = WeaponDataHand;
            WShort.gameObject.SetActive(true);

            WShort.GetComponentInChildren<SpriteRenderer>().sprite = WeaponData.WeaponSprite;

            WShort.Damage = WeaponData.Damage;
            WShort.Cooldown = WeaponData.Cooldown;

            isEquip = false;
        }
    }
}
