using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamfieldTrigger : MonoBehaviour {

    public bool activated;

    void Start()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && activated)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    
	
	// Update is called once per frame
	void Update () {
		
	}
}
