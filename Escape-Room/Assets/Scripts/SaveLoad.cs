using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public List<int> List = new List<int>();
    public Vector3 xyz = new Vector3();
    private SaveData data;
	void Start ()
    {
        Load();
	}
	
	void Update ()
    {
        Save();
	}

    public void Save()
    {
        if (!Directory.Exists(Application.dataPath + "/saves"))
            Directory.CreateDirectory(Application.dataPath + "/saves");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/saves/SaveData.dat");

        CopySaveData();

        bf.Serialize(file, data);
        file.Close();
    }

    public void CopySaveData()
    {
        data.List.Clear();

        foreach(int i in List)
        {
            data.List.Add(i);
        }

        data.position = Vector3ToSerVector3(xyz);
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/saves/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/saves/SaveData.dat", FileMode.Open);

            data = (SaveData)bf.Deserialize(file);

            CopyLoadData();

            file.Close();
        }        
    }

    public void CopyLoadData()
    {
        List.Clear();

        foreach(int i in data.List)
        {
            List.Add(i);
        }

        xyz = SerVector3ToVector3(data.position);
    }

    public static SerVector3 Vector3ToSerVector3(Vector3 V3)
    {
        SerVector3 SV3 = new SerVector3();

        SV3.x = V3.x;
        SV3.y = V3.y;
        SV3.z = V3.z;

        return SV3;
    }
    
    public static Vector3 SerVector3ToVector3(SerVector3 SV3)
    {
        Vector3 V3 = new Vector3();

        V3.x = SV3.x;
        V3.y = SV3.y;
        V3.z = SV3.z;

        return V3;
    }
}

[System.Serializable]
public class SaveData
{
    public SerVector3 position;
    public List<int> List = new List<int>();
}

[System.Serializable]
public class SerVector3
{
    public float x;
    public float y;
    public float z;
}
