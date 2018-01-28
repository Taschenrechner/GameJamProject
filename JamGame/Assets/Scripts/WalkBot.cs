using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBot : MonoBehaviour
{

    Animator anim;
    int forwardanim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        forwardanim = GetComponentInParent<RobotOnOff>().forward;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        {
            float horizontalmove = Input.GetAxis("Horizontal");
            anim.SetFloat("HSpeed", horizontalmove);
            float verticalmove = Input.GetAxis("Vertical");
            anim.SetFloat("VSpeed", verticalmove);
            forwardanim = GetComponentInParent<RobotOnOff>().forward;
            anim.SetInteger("forward", forwardanim);
        }

    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveleft = new Vector3(-1, 0, 0);
            transform.Translate(moveleft * 1f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 moveright = new Vector3(1, 0, 0);
            transform.Translate(moveright * 1f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 movedown = new Vector3(0, 0, -1);
            transform.Translate(movedown * 1f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 moveup = new Vector3(0, 0, 1);
            transform.Translate(moveup * 1f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}
