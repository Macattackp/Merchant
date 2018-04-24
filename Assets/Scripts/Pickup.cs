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
    public bool overburdened = false;

    public List <Transform> smallItem;
    public List<Transform> mediumItem;
    public List<Transform> largeItem;
    public Transform cameraDirection;
    public Transform currentEmpty;

    public Player playerDetails;
    public CarryManager carryManager;

    void Awake()
    {
        TransformListSet();
        cameraDirection = GameObject.Find("Main Camera").transform;
        playerDetails = GameObject.Find("Player").GetComponent<Player>();
        carryManager = GameObject.Find("GameManager").GetComponent<CarryManager>();
        currentEmpty = GameObject.Find("LargeItem1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        PickupItem();
        
    }

    void PickupItem()
    {
        DistanceCheck();
        
    }    

    public void DistanceCheck()
    {
        Overburdened();

        float distance = Vector3.Distance(currentEmpty.transform.position, transform.position);

        if (pickupDistance >= distance && Input.GetKeyDown(KeyCode.E)&&overburdened==false)
        {
            ItemType();
        }
    }

    void CurrentEmptyAssignment(List<Transform> collection, Transform currentlyEmpty)
    {
       int lastFilled = collection.Count;
       currentlyEmpty = collection[lastFilled];
    }

    public void PickupSmallItems()
    {
        
        CurrentEmptyAssignment(smallItem, currentEmpty);
        

    }

    public void PickupMediumItems()
    {

    }

    public void PickupLargeItems()
    {

    }

    public void PickupItemBasic(Transform item)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.parent = item;
        transform.position = item.transform.position;
        isCarried = true;        
    }

    //************************************Dropping Items***********************************\\

    public void ReleaseItem()
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

    //*******************************MISC****************************************************\\

    /// <summary>
    /// Assigns all pickup empty gameobjects for each size of item to a list
    /// </summary>
    public void TransformListSet()
    {
        
        for (int i = 0; i < 10; i++)
        {
            string type = "SmallItem";            
            int number = i+1;

            AddTransformToList(smallItem, type, number);
        }

        for (int i = 0; i < 4; i++)
        {
            string type = "MediumItem";
            int number = i+1;
            AddTransformToList(mediumItem, type, number);
        }

        for (int i = 0; i < 2; i++)
        {
            string type = "LargeItem";
            int number = 1+i;
            AddTransformToList(largeItem, type, number);
        }
    }

    void AddTransformToList(List<Transform> list, string objectType, int number)
    {
        string item = objectType + number;
        list.Add(GameObject.Find(item).transform);
        
    }

    /// <summary>
    /// boolean to tell if player can pick up more items or not
    /// </summary>
    public void Overburdened()
    {
        if (playerDetails.strength < carryManager.carryWeight || carryManager.fullLoad == true)
        {
            overburdened = true;
        }
        else
        {
            overburdened = false;
        }
    }

    /// <summary>
    /// Tells which type of pickup should be called
    /// </summary>
    public void ItemType()
    {
        if (item.itemSize == ItemSize.Small)
        {
            PickupSmallItems();
        }

        else if (item.itemSize == ItemSize.Medium)
        {
            PickupMediumItems();
        }

        else if (item.itemSize == ItemSize.Large)
        {
            PickupLargeItems();
        }
    }
}
