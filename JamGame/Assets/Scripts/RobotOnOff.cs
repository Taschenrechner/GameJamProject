using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotOnOff : MonoBehaviour {

    //private Rigidbody robot;
    public float moveSpeed;
    int forward = 0;
    int backward = 0;

    void Start () {
        //robot = GetComponent<Rigidbody>();
    }

    int Toggle (int x)
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
	void FixedUpdate () {

        if (Input.GetButtonDown("E"))
        {
            forward = Toggle(forward);
            backward = 0;
        }

        if (Input.GetButtonDown("Q"))
        {
            backward = Toggle(backward);
            forward = 0;
        }

        if (forward == 1)
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed);
        }

        if (backward == 1)
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * moveSpeed);
        }

    }
}
