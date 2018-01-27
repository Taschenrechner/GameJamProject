using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPull : MonoBehaviour {

    Rigidbody robot;
    float strength = 1;
    public Transform dest;
    //float robotspeed = RobotOnOff.moveSpeed;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "robot")
        {
            Vector3 v = dest.transform.position - other.transform.position;
            Debug.Log(v.magnitude);
            if (v.magnitude < 0.6f)
            {
                //robotspeed = 0;
                other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                //sound.Stop();
            }
            else
            {
                v = v.normalized;
                other.gameObject.GetComponent<Rigidbody>().AddForce(v * strength, ForceMode.VelocityChange);
            }
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
