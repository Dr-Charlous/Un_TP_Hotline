using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsLong : MonoBehaviour
{
    public int Damage = 1;
    public int Bullets = 100;
    public int BulletsPerShot = 1;

    [SerializeField] GameObject _prefabBullet;
    [SerializeField] float _speed = 10;
    [SerializeField] bool _isScriptOnPlayer = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isScriptOnPlayer && Bullets > 0)
        {
            GameObject obj = Instantiate(_prefabBullet, transform.position, transform.rotation);
            obj.GetComponent<Bullets>().Launcher = this.gameObject;

            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * _speed * Time.deltaTime, ForceMode2D.Impulse);
            Bullets -= BulletsPerShot;
        }
    }
}
