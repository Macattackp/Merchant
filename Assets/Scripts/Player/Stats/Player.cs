using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static Player player = null;

    public int health = 100;
    public int armor = 0;
    public int stamina = 100;
    public int stealth = 10;
    public int strength = 80;

    public int currency = 500;
    public int platinumEarned=0;
    public int goldEarned=0;
    public int silverEarned=0;
    public int copperEarned=0;

    public float carryWeight = 0f;

    public List<Pickup> carriedItems = new List<Pickup>();
    public Pickup pickedupItem;
    public CarryManager carryStatus;
    public Currency CurrencyDictionary;

    public bool interactionMode = false;
    public bool lookingAtContainer = false;

    public GameObject crossHairs;

    private void Awake()
    {
       /* if (player == null)
        {
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);*/

        crossHairs = GameObject.Find("CrossHairs");
        crossHairs.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerState();
        CurrencyDistribution();
	}

    public void PlayerState()
    {
        if (health <= 0)
        {
            PlayerDeath();
        }

        if (Input.GetKey(KeyCode.F))
        {
            interactionMode = true;
            crossHairs.SetActive(true);
        }
        else
        {
            interactionMode = false;
            crossHairs.SetActive(false);
        }
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CurrencyDistribution()
    {
        int remainder = currency % CurrencyDictionary.platinum;

        int currencyCalc = currency - remainder;
        platinumEarned = currencyCalc / CurrencyDictionary.platinum;

        currencyCalc = remainder;
        remainder = currencyCalc % CurrencyDictionary.gold;
        currencyCalc = currencyCalc - remainder;
        goldEarned = currencyCalc / CurrencyDictionary.gold;

        currencyCalc = remainder;
        remainder = currencyCalc % CurrencyDictionary.silver;
        currencyCalc = currencyCalc - remainder;
        silverEarned = currencyCalc / CurrencyDictionary.silver;

        currencyCalc = remainder;
        remainder = currencyCalc % CurrencyDictionary.copper;
        currencyCalc = currencyCalc - remainder;
        copperEarned = currencyCalc / CurrencyDictionary.copper;

    }
}
