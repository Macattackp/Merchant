using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryEnum : MonoBehaviour {

    //****************************CURRENCY**********************************\\
    public enum CurrencyTypes
    {
        Copper,
        Silver,
        Gold,
        Platinum
    }

    //**************************INTERACTIONMODE********************************\\
    public enum InteractionModeState
    {
        Null,
        Item,
        Crate,
        Shopkeeper,
        NPC
    }

    //***************************ITEMS*****************************************\\
    public enum BuffTypes
    {
        None,
        Health,
        Speed,
        Stealth
    }

    public enum ItemCategories
    {
        Raw,
        Processed,
        Goods
    }

    public enum Materials
    {
        //MINER\\
        Copper,
        Tin,
        Gold,
        Iron,
        //FARMER\\

        //WOODSMAN\\

        ///////////////////PROCESSED MATERIALS\\\\\\\\\\\\\\\\\\\\\
        //BLACKSMITH\\

        //CARPENTER\\

        //TAXIDERMIST\\

        //MILLWRIGHT\\
    }

    public enum ItemSize
    {
        Small,
        Medium,
        Large,
        Null
    }

    public enum ItemTypes
    {
        Miner,
        Woodsman,
        Farmer,
        Fisherman,
        Blacksmith,
        Millwright,
        Carpenter,
        Taxidermist,
        Alchemist,
        Weaponsmith,
        Armorsmith,
        Jeweler
    }


    //****************************NPC******************************************\\
    public enum NPCType
    {
        Humanoid,
        Beast,
        Monster
    }

    public enum NPCSpecies
    {
        Human,
        Dwarf,
        Elf,
        Dragonborn,
        Goblin
    }

    public enum NPCRole
    {
        Mob,
        Harvester,
        Refiner,
        Manufacturer,
        Merchant,
        Civilian,
        Soldier
    }


}
