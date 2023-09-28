using System.Collections.Generic;
using UnityEngine;

public class InventorySystemUI : MonoBehaviour
{

    [SerializeField] private Transform itemContent;
    [SerializeField] private GameObject emptyInvenoryItem;


    private void Start()
    {
        InventorySystem.Instance.OnInventoryChange += InventorySystem_OnInventoryChange;
    }

    private void OnDestroy()
    {
        InventorySystem.Instance.OnInventoryChange -= InventorySystem_OnInventoryChange;
    }

    private void InventorySystem_OnInventoryChange(object sender, Dictionary<InventoryItemSO, int> itemsDict)
    {
        UpdateItemsViev(itemsDict);
    }

    public void UpdateItemsViev(Dictionary<InventoryItemSO, int> itemsDict)
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (InventoryItemSO itemSO in itemsDict.Keys)
        {
            GameObject newItem = Instantiate(emptyInvenoryItem, itemContent);
            newItem.GetComponent<ItemPrefabData>().SetData(itemSO, itemsDict[itemSO]);
        }
    }
}
