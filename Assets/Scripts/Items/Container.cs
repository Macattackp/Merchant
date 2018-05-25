using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour {

    public float baseWeight;
    public float currentWeight;
    public float maxWeight;
    public Item containerDetails;
    public List<Item> inventory;

    public bool isFull = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentWeight = containerDetails.weight;		
	}
}
