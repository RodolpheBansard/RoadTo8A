using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemLogic : MonoBehaviour
{
    private const string FILE_PATH = "/data.RBA";
    private DataModel DataModel;

    private void Start()
    {
        DataModel = LoadDataModel();
    }  


    public  void SaveDataModel(DataModel data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + FILE_PATH;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public  DataModel LoadDataModel()
    {
        string path = Application.persistentDataPath + FILE_PATH;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataModel data = formatter.Deserialize(stream) as DataModel;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save not found in " + path);
            return null;
        }
    }

    public void Reset()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + FILE_PATH;
        FileStream stream = new FileStream(path, FileMode.Create);

        DataModel data = new DataModel();


        formatter.Serialize(stream, data);
        stream.Close();
    }
}
