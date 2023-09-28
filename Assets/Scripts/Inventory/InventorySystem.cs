using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    [SerializeField] 
    private Dictionary<InventoryItemSO, int> itemsDict 
        = new Dictionary<InventoryItemSO, int>();

    public Dictionary<InventoryItemSO, int> ItemsDict => itemsDict;

    public event EventHandler<Dictionary<InventoryItemSO, int>> OnInventoryChange;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SaveSystem.Instance.LoadInventory();
    }

    public void Add(InventoryItemSO item)
    {
        item.AddTo(itemsDict);

        SaveSystem.Instance.SaveInventory(itemsDict);

        OnInventoryChange?.Invoke(this, itemsDict);
    }

    public void Remove(InventoryItemSO item)
    {
        item.RemoveFrom(itemsDict);

        SaveSystem.Instance.SaveInventory(itemsDict);

        OnInventoryChange?.Invoke(this, itemsDict);
    }

    [ContextMenu("clear invent")]
    public void SetEmpty()
    {
        itemsDict.Clear();

        OnInventoryChange?.Invoke(this, itemsDict);
    }

    public void SetInventoryFromPathsArray(string []pathArray)
    {
        itemsDict.Clear();

        foreach (string path in pathArray)
        {
            InventoryItemSO itemData = Resources.Load<InventoryItemSO>(path);

            if (itemsDict.ContainsKey(itemData))
            {
                itemsDict[itemData]++;
                continue;
            }

            itemsDict.Add(itemData, 1);
        }

        OnInventoryChange?.Invoke(this, itemsDict);
    }
}
