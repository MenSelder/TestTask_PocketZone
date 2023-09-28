using UnityEngine;

[CreateAssetMenu(fileName = "WeaponItem", menuName = "Item/Create New Weapon Item")]
public class WeaponItemSO : InventoryItemSO, IWeapon
{
    public void Attack()
    {
        Debug.Log("ak-attack");
    }
}
