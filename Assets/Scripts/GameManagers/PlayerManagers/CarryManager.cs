using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public DictionaryEnum.ItemSize carryType = DictionaryEnum.ItemSize.Null;

    public Text floatText;

    private float fadeTime = 5f;


    // Use this for initialization
    void Awake ()
    {
        playerCarry = GameObject.Find("Player").GetComponent<Player>();
        floatText.color = Color.clear;
    }
	
	// Update is called once per frame
	void Update ()
    {
        CarryTypeReset();
        FullLoad();
        ReleaseItem();
	}

    public void FullLoadWarningFadeIn()
    {
        floatText.text = "Your Arms Are Full";
        floatText.color = Color.Lerp(floatText.color, Color.white, fadeTime * Time.deltaTime);  
    }

    public void FullLoadWarningFadeOut()
    {
        floatText.color = Color.Lerp(floatText.color, Color.clear, fadeTime * Time.deltaTime);
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
        if (currentlyHeldItems.Count > 0 && Input.GetMouseButtonDown(0) && playerCarry.interactionMode == false)
        {
            int itemLength = currentlyHeldItems.Count-1;           

            foreach (Pickup items in currentlyHeldItems)
            {
                currentlyHeldItems[itemLength].ThrowItem();
                itemLength--;
            }

            currentlyHeldItems.Clear();
        }
        if (currentlyHeldItems.Count > 0 && Input.GetMouseButtonDown(1) && playerCarry.interactionMode == false)
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
            carryType = DictionaryEnum.ItemSize.Null;
        }
    }
}
