using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="ItemData",menuName ="ItemData/itemData")]
public class ItemData : ScriptableObject
{
    public GameObject ItemUI;
    public GameObject Item;
    public string Name;
    public int ID;
}
