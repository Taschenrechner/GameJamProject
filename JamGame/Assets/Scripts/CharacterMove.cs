using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody rigidbod;
    //public Vector3 respawnPoint;
    //public float Pfeil = 90f;

    void Start()
    {
        rigidbod = GetComponent<Rigidbody>();
        //respawnPoint = GameObject.FindWithTag("Player").GetComponent<Respawnpoint>().respawnPoint;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        if (other.tag == "CheckPoint")
        {
            respawnPoint = other.transform.position;
        }
    }*/
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (!Input.GetButton("Fire1"))
        {
            transform.Translate(new Vector3(0, 0, v) * Time.deltaTime * moveSpeed);
            transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime * moveSpeed);
        }
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
    }
}
