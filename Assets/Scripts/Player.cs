using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public float speed = 3.5f;
    public float jumpPower = 5f;
    public float mouseSensitivity = 3f;

    public static bool isJumping = false;
    new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Rotate();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Vertical");
        float z = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(x, 0, -z);
        transform.Translate(movement * Time.deltaTime * speed);
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void Rotate()
    {
        
        transform.Rotate(0f, Input.GetAxis("Mouse X") * mouseSensitivity, 0f);
        float rx = Camera.main.transform.localRotation.x * 180 + -Input.GetAxis("Mouse Y") * mouseSensitivity;
        if (rx <= 90 && rx >= -90)
        {
            Camera.main.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * mouseSensitivity, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
