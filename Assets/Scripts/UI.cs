using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        cam();
    }

    void cam()
    {
        this.transform.position += new Vector3(0, -Input.GetAxis("Mouse Y")*3f, 0);
        this.transform.Rotate(new Vector3(-(this.transform.localRotation.x + Camera.main.transform.localRotation.x)*7, 0, 0));
        this.transform.position += new Vector3(-Input.GetAxis("Mouse X") * 2f, 0, 0);
        if(Player.isJumping)
        {
            this.transform.position += Vector3.up*10;
        }
        this.transform.position += (new Vector3(Camera.main.pixelWidth / 5, Camera.main.pixelHeight / 6, 0) - this.transform.position) / 3f;
    }
}
