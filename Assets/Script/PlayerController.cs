using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public float Life;

    [SerializeField] float _speed = 1;
    [SerializeField] float _x;
    [SerializeField] float _y;
    [SerializeField] GameObject _mesh;
    [SerializeField] Texture2D _cursorTexture;

    private void Start()
    {
        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        //Move
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
        transform.position += new Vector3(_x, _y) * _speed * Time.deltaTime;

        //Rotate
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _mesh.transform.position;
        _mesh.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
