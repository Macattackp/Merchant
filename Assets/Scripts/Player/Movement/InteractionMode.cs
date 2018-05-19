using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMode : MonoBehaviour {

    public DictionaryEnum.InteractionModeState interactionModeStates = DictionaryEnum.InteractionModeState.Null;

    public bool interactionModeActive = false;
    public bool isCarryingItem = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.F))
        {
            interactionModeActive = true;
        }
        else
        {
            interactionModeActive = false;
        }
		
	}
}
