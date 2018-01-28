using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

    Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //Movement();
        {
            float horizontalmove = Input.GetAxis("Horizontal");
            anim.SetFloat("HSpeed", horizontalmove);
            float verticalmove = Input.GetAxis("Vertical");
            anim.SetFloat("VSpeed", verticalmove);
            transform.eulerAngles = new Vector2(0, 0);
        }
		
	}

}

