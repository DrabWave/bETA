using UnityEngine;
using System.IO;

public class script_JSON : MonoBehaviour
{
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
    public class Item
    {
        public string NameItem;
        public int Level;
    }
}
