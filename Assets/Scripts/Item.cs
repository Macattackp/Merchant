using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemCategories
{
    Raw,
    Processed,
    Goods
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

public enum BuffTypes
{
    None,
    Health,
    Speed,
    Stealth
}

[CreateAssetMenu(fileName = "Item", menuName ="Merchant/Inventory/Item")]
public class Item : ScriptableObject {

    public new string name;
    public float weight;
    public float baseValue;
    public ItemCategories itemCategory;
    public ItemTypes itemType;

    public bool isEdible;
    public float nutrition;
    public BuffTypes buffType;
    public float buffAmount;

    public bool isEquipable;
    public float attack;
    public float defense;
    public float stealthBonus;
}
