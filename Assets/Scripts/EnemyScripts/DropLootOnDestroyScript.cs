using UnityEngine;

public class DropLootOnDestroyScript : MonoBehaviour
{
    public InventoryItemSO lootSO;

    private bool isQuitting = false;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(lootSO.Prefab, transform.position, Quaternion.identity);
        }
    }
}
