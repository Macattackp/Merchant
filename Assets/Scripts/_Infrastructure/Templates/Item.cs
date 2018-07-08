using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName ="Merchant/Inventory/Item")]
public class Item : ScriptableObject {

    public new string name;
    public GameObject sprite;
    public DictionaryEnum.ItemSize itemSize;

    public float weight;
    public float area;

    public float baseValue;
    public int rarity;

    public DictionaryEnum.ItemCategories itemCategory;
    public DictionaryEnum.ItemTypes itemType;

    public List<List<Item>> ingredients;
    public List<Item> toolsNeeded;

    public bool isEdible;
    public float nutrition;
    public DictionaryEnum.BuffTypes buffType;
    public float buffAmount;

    public bool isEquipable;
    public DictionaryEnum.ItemEquipSlot equipSlot;
    public float attack;
    public float defense;
    public float stealthBonus;

    public bool isContainer;
    public float capacity;

    public bool RAW;

    public bool REFINED;
    
    public bool COMPONENT;

    public string componentType;

    public bool PRODUCT;

    public string productType;
}
