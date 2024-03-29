using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int Damage = 1;
    public GameObject Launcher;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != Launcher)
        {
            Ennemy ennemy = collision.GetComponent<Ennemy>();

            if (ennemy != null)
            {
                ennemy.Life -= Damage;

                if (ennemy.Life <= 0)
                {
                    Destroy(ennemy.gameObject);
                }
            }

            Destroy(this.gameObject);
        }
    }
}
