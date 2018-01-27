using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public Transform dest;
    GameObject robot;
    bool turnable;
    Vector3 roationaxis = new Vector3(0, 1, 0);

    void Start () {
        robot = GameObject.FindWithTag("robot");
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "robotCenter")
        {
            GameManager.instance.robotmoveable = false;
            turnable = true;

        }
    }
    // Update is called once per frame
    void Update () {
        /*if (turnable)
        {
            GameManager.instance.robotmoveable = true;
        }*/
		if(turnable && Input.GetButtonDown("T"))
        {
            robot.transform.position= new Vector3(transform.position.x, robot.transform.position.y, transform.position.z);
            robot.transform.RotateAround(transform.position, roationaxis, 90f);
            transform.RotateAround(transform.position, roationaxis, 90f);
            GameManager.instance.robotmoveable = true;
        }
	}
}
