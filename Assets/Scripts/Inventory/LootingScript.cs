using System;
using UnityEngine;

public class LootingScript : MonoBehaviour
{
    public static LootingScript Instance;

    public event EventHandler<InventoryItemSO> OnItemPickUp;

    public void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InventoryItem item;
        if (collision.TryGetComponent(out item))
        {
            InventoryItemSO itemSO = item.ItemSO;

            InventorySystem.Instance.Add(itemSO);
            OnItemPickUp?.Invoke(this, itemSO);

            Destroy(item.gameObject);
        }
    }
}
