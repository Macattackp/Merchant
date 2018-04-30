using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatText : MonoBehaviour {

    public string floatTextString;
    public Text floatText;

    private float fadeTime= 5f;

    private bool _mouseHover;
    private Player _player;
    

	// Use this for initialization
	void Start () {

        floatText.color = Color.clear;
        _player= GameObject.Find("Player").GetComponent<Player>();

    }
	
	// Update is called once per frame
	void Update () {
        FadeText();
	}

    
    private void OnMouseOver()
    {
        _mouseHover = true;
    }

    private void OnMouseExit()
    {
        _mouseHover = false;
    }

    public void FadeText()
    {
        if (_mouseHover && _player.interactionMode == true)
        {
            floatText.text = floatTextString;
            floatText.color = Color.Lerp(floatText.color, Color.white, fadeTime * Time.deltaTime);
        }

        else
        {
            floatText.color = Color.Lerp(floatText.color, Color.clear, fadeTime * Time.deltaTime);            
        }

    }
}
