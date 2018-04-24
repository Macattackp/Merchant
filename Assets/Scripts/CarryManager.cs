using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryManager : MonoBehaviour {

    public int carryWeight = 0;
    public int smallItemsCarried = 0;
    public int mediumItemsCarried = 0;
    public int largeItemsCarried = 0;
    public int maxSmallItems=10;
    public int maxMediumItems=4;
    public int maxLargeItems=2;

    public bool fullLoad = false;
    

    public Player playerCarry;
    public List<Pickup> currentlyHeldItems;


	// Use this for initialization
	void Awake ()
    {
        playerCarry = GameObject.Find("Player").GetComponent<Player>();		
	}
	
	// Update is called once per frame
	void Update ()
    {
        FullLoad();
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
}
