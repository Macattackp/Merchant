using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoin : MonoBehaviour {

    public int coinValue = 1;

    public GameObject coin;

    public Player _player;
    public InteractionMode _interactionMode;

	// Use this for initialization
	void Awake () {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _interactionMode = GameObject.Find("Player").GetComponent<InteractionMode>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (_interactionMode.interactionModeActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _player.currency += coinValue;
                Destroy(coin);
            }
        }
        
    }
}
