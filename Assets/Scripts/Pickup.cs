using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public Item item;

    public float pickupDistance = 1.5f;
    public float throwForce = 1000f;
        
    public bool isCarried = false;
    public bool carriedCall = false;
    public bool withinDistance = false;

    public Transform playerCharacter;
    public Transform cameraDirection;

    public Player playerDetails;

    void Awake()
    {
        playerCharacter = GameObject.Find("ObjectHeld").transform;
        cameraDirection = GameObject.Find("Main Camera").transform;
    }

    // Use this for initialization
    void FixedUpdate ()
    {
        CarryItem();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCheck();
        
    }

    public void DistanceCheck()
    {
        float distance = Vector3.Distance(playerCharacter.transform.position, transform.position);

        if (pickupDistance >= distance && Input.GetKeyDown(KeyCode.E))
        {
            PickupItem();
        }
    }

    public void PickupItem()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.parent = playerCharacter;
        transform.position = playerCharacter.transform.position;
        isCarried = true;
    }

    public void CarryItem()
    {
        if(isCarried==true && Input.GetMouseButtonDown(0))
        {
            ThrowItem();
        }
        if(isCarried==true && Input.GetMouseButtonDown(1))
        {
            DropItem();
        }
    }

    public void ThrowItem()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        isCarried = false;
        GetComponent<Rigidbody>().AddForce(cameraDirection.forward * throwForce);
        GetComponent<Rigidbody>().useGravity = true;
    }

    public void DropItem()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        isCarried = false;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
