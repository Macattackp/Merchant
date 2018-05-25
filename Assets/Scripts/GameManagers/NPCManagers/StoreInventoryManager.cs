using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInventoryManager : MonoBehaviour {

    public int smallItemSlots=10;
    public int mediumItemSlots=8;
    public int largeItemSlots=2;
    public int maxInventory = 80;

    public float harvestTime = 10f;

    public List<Item> itemCatalogue;
    public List<Item> currentInventory;
    public List<Item> willBuy;

    public NPC merchant;

    public bool isHarvester = false;

    private bool _inventoryFull = false;
    private bool _isHarvesting=false;

    // Use this for initialization
    void Start ()
    {
        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        InventoryFilledCheck();
        if (isHarvester == true)
        {
            HarvestResources();
        }
		
	}

    public void InventoryFilledCheck()
    {
        if (currentInventory.Count >= maxInventory)
        {
            _inventoryFull = true;
        }
        else
        {
            _inventoryFull = false;
        }
    }

    public void HarvestResources()
    {        
        if(_isHarvesting==false && _inventoryFull==false)
        {
            _isHarvesting = true;
            ExecuteAfterTime(harvestTime);
        }
        else if (_inventoryFull == true)
        {
            StopCoroutine("ExecuteAfterTime");
            _isHarvesting = false;
        }

    }

    public void CheckIngredients()
    {

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        int itemHarvested= Random.Range(0, itemCatalogue.Count - 1);

        currentInventory.Add(itemCatalogue[itemHarvested]);

        // Code to execute after the delay
    }
}
