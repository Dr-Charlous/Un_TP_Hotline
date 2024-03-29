using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponsLong : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public float Damage = 1;
    public float BulletSpeed = 10;
    public float Cooldown = 1;
    public int Bullets = 100;
    public int BulletsPerShot = 1;
    public bool isInRange = false;

    [SerializeField] GameObject _prefabBullet;
    [SerializeField] bool _isScriptOnPlayer = false;

    private float _cooldown = 0;

    private void Update()
    {
        if (_cooldown <= Cooldown)
            _cooldown += Time.deltaTime;

        if (_isScriptOnPlayer && Input.GetKey(KeyCode.Mouse0) && Bullets > 0 && _cooldown >= Cooldown)
        {
            _cooldown = 0;
            Fire();
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_isScriptOnPlayer && _cooldown >= Cooldown)
        {
            _cooldown = 0;
            Fire();
        }
    }

    void Fire()
    {
        GameObject obj = Instantiate(_prefabBullet, transform.position, transform.rotation);
        obj.GetComponent<Bullets>().Launcher = this.gameObject;

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        obj.GetComponent<Rigidbody2D>().AddForce(direction * BulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
        Bullets -= BulletsPerShot;
    }

    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            isInRange = false;
        }
    }
    #endregion
}
