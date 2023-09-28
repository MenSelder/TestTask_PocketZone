using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]   
public class InventoryItemSO : ScriptableObject
{
    public string PrefabPath;

    public string Name;
    public Sprite Icon;
    public GameObject Prefab;
    public string Discription;

    public virtual void AddTo(Dictionary<InventoryItemSO, int> itemsDict)
    {
        if (itemsDict.ContainsKey(this))
        {
            itemsDict[this]++;
            return;
        }

        itemsDict.Add(this, 1);
    }

    public virtual void RemoveFrom(Dictionary<InventoryItemSO, int> itemsDict)
    {
        if (!itemsDict.ContainsKey(this))
            throw new System.Exception(Name + "do not in inventory");

        itemsDict[this]--;

        if (itemsDict[this] < 1)
        {
            itemsDict.Remove(this);
            return;
        }
    }
}
