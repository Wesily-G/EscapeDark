using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackManager : BaseManager<KnapsackManager>
{
    private List<Item> items = new List<Item>();//记录你背包里有什么
    public ItemLib itemLibary;
    public GameObject Content;
    public void addItem(Item item)
    {
        if (itemLibary.Contain(item))//如果背包数据库里包含物体
        {
          Item _item=  Instantiate(item.gameObject, Content.transform).GetComponent<Item>();
            items.Add(_item);
        }
        
    }
    public void reMoveItem(Item item)
    {
        if (items.Contains(item))
        {
            item.Delete();
            items.Remove(item);
            return;
        }
        Debug.LogError("背包里没有"+item.ID+"物品");
    }
    
}