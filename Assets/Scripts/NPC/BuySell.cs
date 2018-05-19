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
    public List<Item> harvestList = new List<Item>();
    [SerializeField]
    public List<Item> inventory = new List<Item>();

    public float waresCost;
    public float productionTime=30f;

    public int requiredInventory;
    public int maxInventory=10;
    public int amountPerRow = 5;    

    public MerchantType merchantType;

    private Vector3 _merchantLocation;
    private Vector3 _itemSpawnLocation;

    private int _inventory = 0;
    private int _amountInRow = 0;
    private float _time;
    private float _itemSize;

    private int[] _inventoryReference;


    public GameObject[] waresInventory;


    // Use this for initialization
    void Start () {
        _merchantLocation = transform.position;
        waresInventory = new GameObject[maxInventory];
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

    public void CreateItem(int rowSpacing)
    {
        //int row = 0;
        Vector3 merchandiseLocation = new Vector3(_merchantLocation.x + Random.Range(-5, 5), .1f, _merchantLocation.z + Random.Range(-5, 5));
        Instantiate(producedWares,merchandiseLocation,transform.rotation);
    }

    IEnumerator PauseFor(float pauseTime)
    {
        yield return new WaitForSeconds(pauseTime);
    }

    public void ItemMaker()
    {
        Vector3 merchandiseLocation = new Vector3(_merchantLocation.x + Random.Range(-5, 5), .1f, _merchantLocation.z + Random.Range(-5, 5));

        if (merchantType == MerchantType.Harvester && _inventory < maxInventory)
        {
            foreach (GameObject item in waresInventory)
            {
                PauseFor(productionTime);
                waresInventory[_inventory] = Instantiate(producedWares, merchandiseLocation, transform.rotation);
                _amountInRow++;
                _inventory++;
            }
        }

        /*if (merchantType == MerchantType.Harvester && _inventory < maxInventory)
        {
            CreateItem();
            _inventory++;
        }
        else if (merchantType == MerchantType.Manufacturer || merchantType == MerchantType.Refiner || merchantType == MerchantType.Merchant && _inventory >= requiredInventory && _inventory < maxInventory)
        {
            CreateItem();
            _inventory++;
        }*/
    }
}