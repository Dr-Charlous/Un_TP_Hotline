using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjects : MonoBehaviour
{
    public GameObject ObjectLauncher;
    public GameObject PrefabObjectLaunch;

    public GameObject ShortWeapon;
    public GameObject LongWeapon;

    public CharactersWeaponnary CWeapons;

    [SerializeField] float _speed = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && ObjectLauncher != null && CWeapons.isEquip == true && CWeapons.WeaponData.isThrowable == true)
        {
            ShortWeapon.SetActive(false);
            LongWeapon.SetActive(false);

            GameObject obj = Instantiate(PrefabObjectLaunch, ObjectLauncher.transform.position, ObjectLauncher.transform.rotation);
            obj.GetComponent<GrabWeapons>().WeaponData = CWeapons.WeaponData;
            obj.GetComponentInChildren<SpriteRenderer>().sprite = CWeapons.WeaponData.WeaponSprite;

            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * _speed * Time.deltaTime, ForceMode2D.Impulse);

            CWeapons.WeaponData = null;
            CWeapons.isEquip = false;
        }
    }
}
