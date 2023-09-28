using System.Collections.Generic;

[System.Serializable]
public class InventoryData
{
    private string[] pathsArray;

    public InventoryData(Dictionary<InventoryItemSO, int> items)
    {
        var pathsList = new List<string>();

        foreach (var item in items)
        {
            for (var i = 0; i < item.Value; i++)
            {
                pathsList.Add(item.Key.PrefabPath);
            }
        }

        pathsArray = pathsList.ToArray();
    }

    public string[] GetPathsArray() => pathsArray;
}
