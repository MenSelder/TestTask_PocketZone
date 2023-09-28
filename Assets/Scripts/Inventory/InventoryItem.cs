using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private InventoryItemSO itemSO;
    public InventoryItemSO ItemSO => itemSO;    
}
