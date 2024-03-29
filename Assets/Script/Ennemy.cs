using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float Life = 5;
    [SerializeField] GameObject _mesh;
    [SerializeField] PlayerController _playerController;
    [SerializeField] float _speed = 1;

    private void Start()
    {
        GameManager.Instance.Ennemies++;
    }

    private void Update()
    {
        if (_playerController != null)
        {
            //Move
            Vector2 direction = _playerController.transform.position - _mesh.transform.position;
            transform.position += (Vector3)direction * _speed * Time.deltaTime;

            //Rotation
            _mesh.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            _playerController = player;
        }
    }

    public void Die()
    {
        GameManager.Instance.Ennemies--;
        GameManager.Instance.CheckVictory();
        Destroy(this.gameObject);
    }
}
