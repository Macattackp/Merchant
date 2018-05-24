using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour {

    public Item item;

    public string playerName="Player";

    public float pickupDistance = 1.5f;
    public float throwForce = 1000f;    
        
    
    public bool overburdened = false;
    public bool isContainer = false;
    public bool complexObject = false;
    public bool owned = false;

    public List <Transform> smallItem;
    public List<Transform> mediumItem;
    public List<Transform> largeItem;
    public Transform cameraDirection;
    public Transform currentEmpty;

    private bool _isCarried = false;
    private bool _hoverOver = false;
    private bool _withinDistance = false;

    private Player playerDetails;
    private CarryManager carryManager;
    private InteractionMode _interactionSet;

    private Color _highlightColour = Color.yellow;

    private Material originalMaterial;
    private Material temporaryMaterial;

    void Awake()
    {
        TransformListSet();
        cameraDirection = GameObject.Find("Main Camera").transform;
        playerDetails = GameObject.Find(playerName).GetComponent<Player>();
        carryManager = GameObject.Find(playerName).GetComponent<CarryManager>();
        currentEmpty = GameObject.Find("LargeItem1").transform;
        _interactionSet = GameObject.Find(playerName).GetComponent<InteractionMode>();

        if (complexObject == false) //Eventually replace with chooseable game object
        {
            originalMaterial = GetComponent<Renderer>().material;
            temporaryMaterial = new Material(originalMaterial);
            temporaryMaterial.color = _highlightColour;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        PickupItem();
        
    }

    void PickupItem()
    {
        if (carryManager.carryType == item.itemSize || carryManager.carryType == DictionaryEnum.ItemSize.Null)
        {
            DistanceCheck();
        }       
        
    }    

    public void DistanceCheck()
    {
        Overburdened();        

        float distance = Vector3.Distance(currentEmpty.transform.position, transform.position);

        if(pickupDistance >= distance)
        {
            _withinDistance = true;
        }
        else
        {
            _withinDistance = false;
        }

        if (_withinDistance && Input.GetMouseButtonDown(0) && !overburdened && !_isCarried && _hoverOver && playerDetails.interactionMode)
        {
            ItemType();
        }

        else if (overburdened == true && Input.GetMouseButtonDown(0) && playerDetails.interactionMode == true)
        {
            return;
        }
    }

    
    void PickupCalc(List<Transform> collection, Vector3 rotation)
    {
        int lastFilled = carryManager.currentlyHeldItems.Count;
        
        currentEmpty = collection[lastFilled];
        carryManager.currentlyHeldItems.Add(this);
        //Debug.Log(currentEmpty);

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.parent = currentEmpty;
        transform.position = currentEmpty.transform.position;
        transform.localEulerAngles = rotation;
        _isCarried = true;

        carryManager.carryWeight = carryManager.carryWeight + item.weight;
    }

    public void PickupSmallItems()
    {
        Vector3 rotation = new Vector3(0, 0, 0);
        carryManager.carryType = DictionaryEnum.ItemSize.Small;
        PickupCalc(smallItem, rotation);
    }

    public void PickupMediumItems()
    {
        Vector3 rotation = new Vector3(90, 0, 90);
        carryManager.carryType = DictionaryEnum.ItemSize.Medium;
        PickupCalc(mediumItem, rotation);
    }

    public void PickupLargeItems()
    {
        Vector3 rotation = new Vector3(0, 0, 0);
        carryManager.carryType = DictionaryEnum.ItemSize.Large;
        PickupCalc(largeItem, rotation);
    }

    public void PickupItemBasic(Transform item)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.parent = item;
        transform.position = item.transform.position;
        _isCarried = true;        
    }

    //************************************Dropping Items***********************************\\
    public void ThrowItem()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        _isCarried = false;
        GetComponent<Rigidbody>().AddForce(cameraDirection.forward * throwForce);
        GetComponent<Rigidbody>().useGravity = true;

        carryManager.carryWeight = carryManager.carryWeight-item.weight;        
    }

    public void DropItem()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        _isCarried = false;
        GetComponent<Rigidbody>().useGravity = true;

        carryManager.carryWeight = carryManager.carryWeight - item.weight;       
    }

    //*******************************MISC****************************************************\\

    /// <summary>
    /// Assigns all pickup empty gameobjects for each size of item to a list
    /// </summary>
    public void TransformListSet()
    {
        //int hi = carryManager.maxSmallItems;
        //Debug.Log(hi);
        
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
        if (playerDetails.strength < carryManager.carryWeight || carryManager.fullLoad == true || carryManager.carryWeight + item.weight > playerDetails.strength)
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
        
        if (item.itemSize == DictionaryEnum.ItemSize.Small)
        {
            PickupSmallItems();
            //Debug.Log(item.itemSize);
        }

        else if (item.itemSize == DictionaryEnum.ItemSize.Medium)
        {
            PickupMediumItems();
            //Debug.Log(item.itemSize);
        }

        else if (item.itemSize == DictionaryEnum.ItemSize.Large)
        {
            PickupLargeItems();
            //Debug.Log(item.itemSize);
        }
    }

    //********************************WHEN MOUSE IS OVER*****************************

    private void OnMouseOver()
    {
        if (playerDetails.interactionMode && !_isCarried && _withinDistance)
        {
            _hoverOver = true;

            if (overburdened==true)
            {
                carryManager.FullLoadWarningFadeIn();
            }

            if (complexObject == false)
            {
                GetComponent<Renderer>().material = temporaryMaterial;
            }

            if (isContainer == true)
            {
                _interactionSet.interactionModeStates = DictionaryEnum.InteractionModeState.Crate;
                playerDetails.lookingAtContainer = true;
            }
        }
    }

    private void OnMouseExit()
    {
        _hoverOver = false;
        carryManager.FullLoadWarningFadeOut();
        _interactionSet.interactionModeStates = DictionaryEnum.InteractionModeState.Null;

        if (complexObject == false)
        {
            GetComponent<Renderer>().material = originalMaterial;
        }

        if (isContainer == true)
        {
            playerDetails.lookingAtContainer = false;
        }
    }
}
