using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemDatas", menuName = "ItemData/itemDatas")]
public class ItemLib : ScriptableObject
{
    public List<ItemData> itemDatas;
    public bool Contain(Item item)
    {
        for (int i = 0; i < itemDatas.Count; i++)
        {
            if (itemDatas[i].ID == item.ID)
            {
                return true;
            }
        }
        return false;
    }
}