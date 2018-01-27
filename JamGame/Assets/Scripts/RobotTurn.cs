using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTurn : MonoBehaviour {
    Collider robotCol;
    Collider platformCol;
    float t;
    bool isInsideCollider;
    Vector3 point;
    Vector3 roationaxis = new Vector3(0, 1, 0);

    void Start () {
        robotCol = GetComponent<Collider>();
	}

    

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "turnplatform") {
            point = other.transform.position;
            float x;
            float y;
            platformCol = other.gameObject.GetComponent<Collider>();
            Vector3 pl = other.transform.position;
            x = Math.Abs(pl[0]);
            robotCol = other.gameObject.GetComponent<Collider>();
            Vector3 ro = transform.position;
            y = Mathf.Abs(ro[0]);
            if (t <= x/2 - y/2) {
                isInsideCollider = true;
                Debug.Log(t);
            }
            else
            {
                isInsideCollider = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("T") && isInsideCollider)
        {
            transform.RotateAround(point, roationaxis,90f);
        }
    }
}
