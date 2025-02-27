using UnityEngine;
using System.IO;

public class script_JSON : MonoBehaviour
{
    
    // ________!STOP!_____________ - dont do it
    
    
    
    public Item item;

    [ContextMenu("Load")]
    public void LoadField()
    {
        item = JsonUtility.FromJson<Item>(File.ReadAllText(Application.streamingAssetsPath + "/JSON.json"));

    }
    [ContextMenu("Save")]
    public void SaveField()
    {
        File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(item));
    }


    [System.Serializable]


    // Will add vars for abstract inventory with List<>;
    public class Item
    {
        public string NameItem;
        public int Level;
    }
}
