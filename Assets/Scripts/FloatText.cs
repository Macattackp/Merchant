using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatText : MonoBehaviour {

    public string floatTextString;
    public Text floatText;

    private float fadeTime= 5f;

    private bool textVisible;

	// Use this for initialization
	void Start () {

        floatText.color = Color.clear;
		
	}
	
	// Update is called once per frame
	void Update () {
        FadeText();
	}

    private void OnMouseOver()
    {
        textVisible = true;
    }

    private void OnMouseExit()
    {
        textVisible = false;
    }

    public void FadeText()
    {
        if (textVisible)
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
