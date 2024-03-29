using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabWeapons : MonoBehaviour
{
    public CharactersWeaponnary Weapons;
    public WeaponsData WeaponData;

    [SerializeField] ThrowObjects _throw;
    [SerializeField] PlayerController _playerController;


    private void Update()
    {
        if (_playerController != null && Input.GetKeyDown(KeyCode.Mouse1) && Weapons != null && Weapons.isEquip == false)
        {
            Weapons.WLong.gameObject.SetActive(false);
            Weapons.WShort.gameObject.SetActive(false);

            if (WeaponData.isLongRangeWeapon)
            {
                LongWeaponInit(Weapons.WLong, WeaponData);
            }
            else
            {
                ShortWeaponInit(Weapons.WShort, WeaponData);
            }
            
            Weapons.WeaponData = WeaponData;

            Destroy(this.gameObject);
        }
    }

    #region Collsions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            _playerController = player;
            Weapons = player.GetComponentInChildren<CharactersWeaponnary>();
            _throw = player.GetComponentInChildren<ThrowObjects>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            _playerController = null;
            Weapons = null;
            _throw = null;
        }
    }
    #endregion

    void ShortWeaponInit(WeaponsShort WShort, WeaponsData WData)
    {
        WShort.gameObject.SetActive(true);
        WShort.Sprite.sprite = WData.WeaponSprite;
        WShort.Damage = WData.Damage;
        WShort.Cooldown = WData.Cooldown;
    }

    void LongWeaponInit(WeaponsLong WLong, WeaponsData WData)
    {
        WLong.gameObject.SetActive(true);
        WLong.Sprite.sprite = WData.WeaponSprite;
        WLong.Damage = WData.Damage;
        WLong.Cooldown = WData.Cooldown;
        WLong.Bullets = WData.Bullets;
        WLong.BulletSpeed = WData.BulletSpeed;
        WLong.BulletsPerShot = WData.BulletsPerShot;
    }
}
