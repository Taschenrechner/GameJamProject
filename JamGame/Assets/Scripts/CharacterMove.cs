using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody rigidbod;
    //public Vector3 respawnPoint;
    //public float Pfeil = 90f;
    public bool moveable = true;
    private KeyCombo charge = new KeyCombo(new string[] { "w", "a", "s", "d" });

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

        if (!Input.GetButton("Fire1") && moveable)
        {
            transform.Translate(new Vector3(0, 0, v) * Time.deltaTime * moveSpeed);
            transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime * moveSpeed);
        }

    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (charge.Check() && !moveable)
        {
            GameManager.instance.energy += 10;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "robot")
        {
            if (GameManager.instance.activeItem == "oil")
            {
                if (Input.GetButtonDown("F") && moveable)
                {
                    moveable = false;
                }
                else if(Input.GetButtonDown("F") && !moveable)
                {
                    moveable = true;
                }

            }
        }
    }
}
