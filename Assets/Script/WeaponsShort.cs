using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponsShort : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public float Damage = 1;
    public float Cooldown = 1;
    private float _cooldown = 0;

    [SerializeField] Ennemy _ennemyTrigger;
    [SerializeField] PlayerController _playerTrigger;
    [SerializeField] bool _isScriptOnPlayer = false;

    private void Update()
    {
        if (_cooldown <= Cooldown)
            _cooldown += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && _ennemyTrigger != null && _isScriptOnPlayer && _cooldown >= Cooldown)
        {
            _cooldown = 0;
            Cut(_ennemyTrigger);
        }

        if (_playerTrigger != null && !_isScriptOnPlayer && _cooldown >= Cooldown)
        {
            _cooldown = 0;
            Cut(_playerTrigger);
        }
    }

    void Cut(Ennemy ennemy)
    {
        ennemy.Life -= Damage;

        if (ennemy.Life <= 0)
        {
            ennemy.Die();
        }
    }

    void Cut(PlayerController player)
    {
        player.Life -= Damage;

        if (player.Life <= 0)
        {
            player.Die();
        }
    }

    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ennemy ennemy = collision.GetComponent<Ennemy>();

        if (ennemy != null && ennemy != _ennemyTrigger)
        {
            _ennemyTrigger = ennemy;
        }

        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null && player != _playerTrigger)
        {
            _playerTrigger = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Ennemy ennemy = collision.GetComponent<Ennemy>();

        if (ennemy != null)
        {
            _ennemyTrigger = null;
        }

        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null && player != _playerTrigger)
        {
            _playerTrigger = null;
        }
    }
    #endregion
}
