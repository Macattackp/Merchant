using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour {

    public bool showText = true;

    public Text info;
    public string platinumOwned;
    public string goldOwned;
    public string silverOwned;
    public string copperOwned;
    public Color activeColor = Color.white;

    public Player playerInfo;

	// Use this for initialization
	void Awake ()
    {
        playerInfo= GameObject.Find("Player").GetComponent<Player>();
        platinumOwned = playerInfo.platinumEarned.ToString();
        goldOwned = playerInfo.goldEarned.ToString();
        silverOwned = playerInfo.silverEarned.ToString();
        copperOwned = playerInfo.copperEarned.ToString();
        //info.text = playerInfo.currency.ToString();
        info.color = Color.white;
    }
	
	// Update is called once per frame
	void Update ()
    {
        platinumOwned = playerInfo.platinumEarned.ToString();
        goldOwned = playerInfo.goldEarned.ToString();
        silverOwned = playerInfo.silverEarned.ToString();
        copperOwned = playerInfo.copperEarned.ToString();
        activeColor.a = 100;
        info.text = platinumOwned+" P/ "+goldOwned+" G/ " + silverOwned+" S/ "+copperOwned+" C/ ";
        info.color = activeColor;
        //StateCheck();
        //ShowText();
    }

    void StateCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (showText == true)
            {
                showText = false;
            }
            else
            {
                showText = true;
            }
        }
    }

    void ShowText()
    {
        if (showText == true)
        {
            info.color = Color.white;
        }
        else
        {
            info.color = Color.clear;
        }
    }
}
