using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName ="Merchant/Inventory/Item")]
public class Item : ScriptableObject {

    public new string name;
    public DictionaryEnum.ItemSize itemSize;
    public float weight;
    public float area;
    public float baseValue;
    public DictionaryEnum.ItemCategories itemCategory;
    public DictionaryEnum.ItemTypes itemType;

    public bool isEdible;
    public float nutrition;
    public DictionaryEnum.BuffTypes buffType;
    public float buffAmount;

    public bool isEquipable;
    public float attack;
    public float defense;
    public float stealthBonus;

    public bool isContainer;
    public float capacity;
    public float maxWeight;
}
