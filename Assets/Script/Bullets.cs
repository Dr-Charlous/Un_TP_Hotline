using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int Damage = 1;
    public GameObject Launcher;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Launcher.GetComponent<Ennemy>() != null && collision.GetComponent<Ennemy>() == null)
        {
            DamageBullet(collision.GetComponent<Ennemy>());
        }
        
        if (Launcher.GetComponent<PlayerController>() != null && collision.GetComponent<PlayerController>() == null)
        {
            DamageBullet(collision.GetComponent<PlayerController>());
        }

        Destroy(this.gameObject);
    }

    void DamageBullet(Ennemy ennemy)
    {
        if (ennemy != null)
        {
            ennemy.Life -= Damage;

            if (ennemy.Life <= 0)
            {
                ennemy.Die();
            }
        }
    }

    void DamageBullet(PlayerController player)
    {
        if (player != null)
        {
            player.Life -= Damage;

            if (player.Life <= 0)
            {
                player.Die();
            }
        }
    }
}
