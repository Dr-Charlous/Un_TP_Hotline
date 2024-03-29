using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsShort : MonoBehaviour
{
    public int Damage = 1;
    [SerializeField] Ennemy _ennemyTrigger;
    [SerializeField] bool _isScriptOnPlayer = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _ennemyTrigger != null && _isScriptOnPlayer)
        {
            _ennemyTrigger.Life -= Damage;

            if (_ennemyTrigger.Life <= 0)
            {
                Destroy(_ennemyTrigger.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ennemy ennemy = collision.GetComponent<Ennemy>();

        if (ennemy != null && ennemy != _ennemyTrigger)
        {
            _ennemyTrigger = ennemy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Ennemy ennemy = collision.GetComponent<Ennemy>();

        if (ennemy != null)
        {
            _ennemyTrigger = null;
        }
    }
}
