using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int Life = 5;

    private void Start()
    {
        GameManager.Instance.Ennemies++;
    }

    public void Die()
    {
        GameManager.Instance.Ennemies--;
        GameManager.Instance.CheckVictory();
        Destroy(this.gameObject);
    }
}
