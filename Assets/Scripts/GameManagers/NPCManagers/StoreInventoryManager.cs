using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInventoryManager : MonoBehaviour {

    public int smallItemSlots=10;
    public int mediumItemSlots=8;
    public int largeItemSlots=2;

    public List<GameObject> itemCatalogue;

	// Use this for initialization
	void Start ()
    {
        int totalInventory = smallItemSlots + mediumItemSlots + largeItemSlots;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
