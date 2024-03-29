using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjects : MonoBehaviour
{
    public GameObject ObjectLauncher;
    public GameObject PrefabObjectLaunch;
    [SerializeField] float _speed = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && ObjectLauncher != null)
        {
            GameObject obj = Instantiate(PrefabObjectLaunch, ObjectLauncher.transform.position, ObjectLauncher.transform.rotation);

            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * _speed * Time.deltaTime, ForceMode2D.Impulse);
            ObjectLauncher = null;
        }
    }
}
