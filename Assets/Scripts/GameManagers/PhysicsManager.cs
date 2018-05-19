using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour {

    public GameObject player;

    private float _maxDistance = 50f;

	// Use this for initialization
	void Awake ()
    {
        player = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update ()
    {
        PhysicsCheck();
		
	}

    void PhysicsCheck()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance >= _maxDistance)
        {
            PhysicsOff();
        }
        else
        {
            PhysicsOn();
        }
    }

    void PhysicsOff()
    {
        GetComponent<Rigidbody>().isKinematic = true;

    }
    void PhysicsOn()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
