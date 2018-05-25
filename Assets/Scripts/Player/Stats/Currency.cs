using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Currency : MonoBehaviour {

    public int platinum = 50000000;
    public int gold = 50000;
    public int silver = 100;
    public int copper = 1;

    private int _platinumtoGold = 10000;
    private int _goldtoSilver = 1000;
    private int _silvertoCopper = 100;
    	
	void Update () {
		
	}

    public void MoneyConversion()
    {

    }

    void MoneyUp()
    {
        if (copper >= _silvertoCopper)
        {
            copper = 0;
            silver = +1;
        }

        if (silver >= _goldtoSilver)
        {
            silver = 0;
            gold = +1;
        }

        if (gold >= _platinumtoGold)
        {
            gold = 0;
            platinum = +1;
        }
    }

    void MoneyDown()
    {
        if (copper < 0)
        {
            silver = -1;
            copper = _silvertoCopper;
        }

        if (silver < 0)
        {
            gold = -1;
            silver = _goldtoSilver;
        }
        if (gold < 0)
        {
            platinum = -1;
            gold = _platinumtoGold;
        }
    }
}
