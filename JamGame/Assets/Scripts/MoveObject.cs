using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    Rigidbody bod;
	void Start () {
        bod = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "robot")
        {
            bod.isKinematic = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "robot")
        {
            bod.isKinematic = true;
        }
    }
}
