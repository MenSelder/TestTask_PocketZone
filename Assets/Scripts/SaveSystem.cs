using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    private readonly BinaryFormatter formatter = new BinaryFormatter();

    private const string PATH = "/inventory.cringe";

    private void Awake()
    {
        Instance = this;
    }

    public void SaveInventory(Dictionary<InventoryItemSO, int> items)
    {
        string path = Application.persistentDataPath + PATH;
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            InventoryData data = new InventoryData(items);

            formatter.Serialize(fileStream, data);
        }
    }

    public void LoadInventory()
    {
        string path = Application.persistentDataPath + PATH;
        if (File.Exists(path))
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                InventoryData data = (InventoryData)formatter.Deserialize(fileStream);
                string[] pathArray = data.GetPathsArray();

                InventorySystem.Instance.SetInventoryFromPathsArray(pathArray);
            }
        }
        else
        {
            //throw new System.Exception("Save inventory file not found!");
            Debug.Log("Save inventory file not found!");
            Debug.Log("Creating empty invent save");

            InventorySystem.Instance.SetEmpty();
            LoadInventory();
        }
    }
}
