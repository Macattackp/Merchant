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

    public float carryWeight = 0f;

    public List<Pickup> carriedItems = new List<Pickup>();
    public Pickup pickedupItem;
    public CarryManager carryStatus;
    public Currency Currency;

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
}
