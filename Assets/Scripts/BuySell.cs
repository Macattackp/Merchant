using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MerchantType
{
    Harvester,
    Refiner,
    Manufacturer,
    Merchant,
    Consumer
}

public class BuySell : MonoBehaviour {

    public GameObject requiredMaterial;
    public GameObject producedWares;

    [SerializeField]
    public List<HarvestList> harvestList = new List<HarvestList>();
    [SerializeField]
    public List<ItemValue> itemValue = new List<ItemValue>();

    public float materialValue;
    public float waresCost;
    public float productionTime=30f;

    public int requiredInventory;
    public int maxInventory=10;

    public MerchantType merchantType;

    private Vector3 _merchantLocation;

    private int _inventory = 0;
    private float _time;


	// Use this for initialization
	void Start () {
        _merchantLocation = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        _time = Time.deltaTime;

        if (_time >= productionTime)
        {
            ItemMaker();
            _time = 0.0f;
        }
              		
	}

    public void CreateItem()
    {
        Vector3 merchandiseLocation = new Vector3(_merchantLocation.x + Random.Range(-5, 5), .1f, _merchantLocation.z + Random.Range(-5, 5));
        Instantiate(producedWares,merchandiseLocation,transform.rotation);
    }

    public void ItemMaker()
    {
        if (merchantType == MerchantType.Harvester && _inventory < maxInventory)
        {
            CreateItem();
            _inventory++;
        }
        else if (merchantType == MerchantType.Manufacturer || merchantType == MerchantType.Refiner || merchantType == MerchantType.Merchant && _inventory >= requiredInventory && _inventory < maxInventory)
        {
            CreateItem();
            _inventory++;
        }
    }
}

public class HarvestList : MonoBehaviour
{
    public GameObject harvestedItem;
    public float harvestProbability;
}

public class ItemValue : MonoBehaviour
{
    public GameObject item;
    public float itemValue;
}

