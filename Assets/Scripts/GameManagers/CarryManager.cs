using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryManager : MonoBehaviour {

    public float carryWeight = 0;
    public int smallItemsCarried = 0;
    public int mediumItemsCarried = 0;
    public int largeItemsCarried = 0;
    public int maxSmallItems=10;
    public int maxMediumItems=4;
    public int maxLargeItems=2;

    public bool fullLoad = false;
    

    public Player playerCarry;
    public List<Pickup> currentlyHeldItems;

    public ItemSize carryType = ItemSize.Null;


    // Use this for initialization
    void Awake ()
    {
        playerCarry = GameObject.Find("Player").GetComponent<Player>();		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CarryTypeReset();
        FullLoad();
        ReleaseItem();
	}

    public void FullLoad()
    {
        if (smallItemsCarried >= maxSmallItems || mediumItemsCarried >= maxMediumItems || largeItemsCarried >= maxLargeItems)
        {
            fullLoad = true;
        }
        else
        {
            fullLoad = false;
        }
    }

    public void ReleaseItem()
    {
        if (currentlyHeldItems.Count >0 && Input.GetMouseButtonDown(0))
        {
            int itemLength = currentlyHeldItems.Count-1;           

            foreach (Pickup items in currentlyHeldItems)
            {
                currentlyHeldItems[itemLength].ThrowItem();
                itemLength--;
            }

            currentlyHeldItems.Clear();
        }
        if (currentlyHeldItems.Count > 0 && Input.GetMouseButtonDown(1))
        {
            int itemLength = currentlyHeldItems.Count-1;
            currentlyHeldItems[itemLength].DropItem();
            currentlyHeldItems.RemoveAt(itemLength);
            //Debug.Log(itemLength);
        }
    }

    void CarryTypeReset()
    {
        if (currentlyHeldItems.Count == 0)
        {
            carryType = ItemSize.Null;
        }
    }
}
