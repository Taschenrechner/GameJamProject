using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUp : MonoBehaviour {
    float t;
    Vector3 startpos;
    Vector3 target;
    float timetoreachtarget;
    Vector3 liftupvec;


    // Use this for initialization
    void Start () {
        startpos = target = transform.position;
        liftupvec = new Vector3(transform.position.x, 5, transform.position.z);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "robot")
        {
            GameManager.instance.liftable = true;
            GameManager.instance.liftableObject = this.gameObject;

        }
    }

    public void ActivateLift()
    {
        //transform.Translate(Vector3.up * Time.deltaTime);
        SetDestination(liftupvec, 10);

    }
    // Update is called once per frame
    void Update () {
        t += Time.deltaTime / timetoreachtarget;
        transform.position = Vector3.Lerp(startpos, target, t);
	}
    public void SetDestination(Vector3 destination, float time)
    {
        t = 0;
        startpos = transform.position;
        timetoreachtarget = time;
        target = destination;
    }
}
