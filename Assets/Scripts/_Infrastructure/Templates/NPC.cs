using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "Merchant/Inventory/NPC")]
public class NPC : ScriptableObject {


    public DictionaryEnum.NPCType type;
    public string npcName;
    public DictionaryEnum.NPCSpecies species;
    public DictionaryEnum.NPCRole role;
    public bool hostile = false;
}
