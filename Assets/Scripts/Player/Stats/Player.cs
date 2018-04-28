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

    private void Awake()
    {
        if (player == null)
        {
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
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
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
}
