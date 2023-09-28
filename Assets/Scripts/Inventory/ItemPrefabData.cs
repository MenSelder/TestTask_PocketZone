using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPrefabData : MonoBehaviour
{
    public InventoryItemSO InventoryItemSO { get; private set; }

    [SerializeField] private Button deleteButton;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private Image image;

    public int Amount { get; set; }

    private void Awake()
    {
        deleteButton.onClick.AddListener(() =>
        {
            InventorySystem.Instance.Remove(InventoryItemSO);
        });
    }

    private void OnDestroy()
    {
        deleteButton?.onClick.RemoveAllListeners();
    }

    public void SetData(InventoryItemSO itemSO, int amount)
    {
        nameText.text = itemSO.Name;
        image.sprite = itemSO.Icon;
        InventoryItemSO = itemSO;

        SetAmount(amount);
    }

    private void SetAmount(int amount)
    {
        Amount = amount;

        amountText.text = Amount.ToString();

        if (amount < 2)
        {
            amountText.gameObject.SetActive(false);
        }
    }
}
