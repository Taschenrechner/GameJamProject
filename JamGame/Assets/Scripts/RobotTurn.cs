using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTurn : MonoBehaviour {
    Collider robotCol;
    Collider platformCol;
    bool isInsideCollider;
    Vector3 point;
    Vector3 roationaxis = new Vector3(0, 1, 0);
    int forward;
    int backward;
    float robotspeed;
    public int pullDistance;
    Collider platformobj;
    float distance;

    void Start () {
        robotCol = GetComponent<Collider>();
       // forward = RobotOnOff.forward;
        //backward = RobotOnOff.backward;
        //robotspeed = RobotOnOff.moveSpeed;
	}

    

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "turnplatform") {
            platformobj = other;
            /*point = other.transform.position;
            float x;
            float y;
            platformCol = other.gameObject.GetComponent<Collider>();
            Vector3 pl = other.transform.position;
            x = Math.Abs(pl[0]);
            robotCol = other.gameObject.GetComponent<Collider>();
            Vector3 ro = transform.position;
            y = Mathf.Abs(ro[0]);*/
            Vector3 movedirect = new Vector3(platformobj.transform.position.x - transform.position.x, 0, platformobj.transform.position.z - transform.position.z);
            Vector3 xzrobot = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 xzplat = new Vector3(other.transform.position.x, 0, other.transform.position.z);
            distance = Vector3.Distance(xzplat, xzrobot);
            if (distance == 0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                isInsideCollider = true;
            }
            else
            {
                movedirect = movedirect.normalized;
                GetComponent<Rigidbody>().AddForce(movedirect * robotspeed, ForceMode.VelocityChange);
                //transform.Translate(movedirect * Time.deltaTime * robotspeed);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        /*if (isInsideCollider)
        {
            Vector3 movedirect = new Vector3(distance, 0, platformobj.transform.position.z);
            if(transform.position != platformobj.transform.position)
            {
                transform.Translate(movedirect * Time.deltaTime * robotspeed);
            }
            isInsideCollider = true;
            forward = 0;
            backward = 0;
        }*/

        if (Input.GetButtonDown("T") && isInsideCollider)
        {
            transform.RotateAround(point, roationaxis,90f);
        }
    }
}
