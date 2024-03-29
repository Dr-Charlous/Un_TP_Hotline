using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Weaponary", order = 1)]
public class WeaponsData : ScriptableObject
{
    public Sprite WeaponSprite;
    public bool isLongRangeWeapon = false;
    public bool isThrowable = true;

    [Header("General datas Weapon :")]
    public float Damage = 1;
    public float Cooldown = 1;

    [Header("If Long Range Weapon :")]
    public float BulletSpeed = 10;
    public int Bullets = 100;
    public int BulletsPerShot = 1;
}
