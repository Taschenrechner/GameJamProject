using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    Renderer ren;
    Collider col;

    void Start()
    {
        ren = gameObject.GetComponent<Renderer>();
        col = gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.Addtoinv(this.gameObject);
            ren.enabled = false;
            col.enabled = false;
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
