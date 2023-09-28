using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AmmoItem", menuName = "Item/Create New Ammo Item")]
public class AmmoItemSO : InventoryItemSO
{
    public int amount;
    public GameObject projectilePrefab;

    public override void AddTo(Dictionary<InventoryItemSO, int> itemsDict)
    {
        if (itemsDict.ContainsKey(this))
        {
            itemsDict[this] += amount;
            return;
        }

        itemsDict.Add(this, amount);
    }
}
