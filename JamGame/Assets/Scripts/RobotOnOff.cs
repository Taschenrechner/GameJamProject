using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotOnOff : MonoBehaviour
{

    //private Rigidbody robot;
    public float moveSpeed = 1;
    public int forward = 0;
    public int backward = 0;
    Vector3 roationaxis = new Vector3(0, 1, 0);
    public bool isInsideCollider;
    public bool triggerState = true;

    void Start()
    {
        //robot = GetComponent<Rigidbody>();
    }

    int Toggle(int x)
    {
        if (x == 0)
            x = 1;
        else
        {
            x = 0;
        }
        return x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.instance.energy < 0.1)
        {
            forward = 0;
            backward = 0;
        }

        if (Input.GetButtonDown("E"))
        {
            moveSpeed = 1;
            forward = Toggle(forward);
            backward = 0;
        }

        if (Input.GetButtonDown("Q"))
        {
            moveSpeed = 1;
            backward = Toggle(backward);
            forward = 0;
        }

        if (forward == 1 && GameManager.instance.energy >= 0.1)
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed);
            GameManager.instance.energy -= 0.1f;
        }

        if (backward == 1 && GameManager.instance.energy >= 0.1)
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * moveSpeed);
            GameManager.instance.energy -= 0.1f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "platform")
        {
            forward = 0;
            backward = 0;
            triggerState = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "platform")
        {
            Vector3 destination = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            Vector3 robotVec = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 forceDirection = destination - robotVec;


            if (forceDirection.magnitude <= 0.85f && triggerState)
            {
                transform.position = destination;
                //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                other.GetComponent<BoxCollider>().isTrigger = false;
                triggerState = false;
                isInsideCollider = true;
            }

            else if (triggerState)
            {
                transform.Translate(forceDirection.normalized * Time.deltaTime);
            }

            if (Input.GetButtonDown("T") && isInsideCollider)
            {
                transform.RotateAround(transform.position, roationaxis, 90f);
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "platform")
            other.GetComponent<BoxCollider>().isTrigger = true;
    }
}
