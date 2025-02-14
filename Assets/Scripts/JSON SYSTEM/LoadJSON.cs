using UnityEngine;
using UnityEngine.UI;
using UnityEngine.IO;

public class LoadJSON : MonoBehaviour
{

    // json system of quest elements

    private JsonFile _jsonFile = new JsonFile();
    private string _path;

    private void Start()
    {
        _path = Application.streamingAssetsPath + "/" + "LevelInfo";

        //_jsonFile = JsonUtility.FromJson<JsonFile>(File.ReadAllText(_path));


    }




    public class JsonFile
    {
        
    }
}
