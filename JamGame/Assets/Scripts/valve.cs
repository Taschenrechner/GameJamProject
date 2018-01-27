using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valve : MonoBehaviour {

    public bool valveToggle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "robot")
        {
            //GameManager.instance.robotmoveable = false;
            GameManager.instance.wrenchable = true;
            GameManager.instance.wrenchableobject = this.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "robot")
        {
            GameManager.instance.wrenchable = false;
        }
    }

    public void ActivateValve()
    {
        Debug.Log("blabla");
        foreach (Transform child in transform)
        {

            if (child.gameObject.GetComponent<SteamfieldTrigger>().activated){
                child.gameObject.GetComponent<SteamfieldTrigger>().activated = false;
            }
            else
            {
                child.gameObject.GetComponent<SteamfieldTrigger>().activated = true;
            }
        }
    }
}
