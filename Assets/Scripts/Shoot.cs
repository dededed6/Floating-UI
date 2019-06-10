using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    AudioSource audioSource;
    new Rigidbody rigidbody;
    void Start()
    {
        audioSource = GetComponent <AudioSource> ();
        rigidbody = GetComponent <Rigidbody> ();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1))
        {
            Fire();
        }
    }
    void Fire()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));
        audioSource.Play();
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (hit.transform.tag == "Entity")
            {
                hit.transform.GetComponent<AudioSource>().Play();
                if (Input.GetMouseButtonDown(0))
                {
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                    hit.rigidbody.AddForce((hit.transform.position - this.transform.position).normalized * 1000f);
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.white;
                    hit.rigidbody.AddForce((this.transform.position - hit.transform.position).normalized * 1000f);
                }
            }
        }
    }
}
