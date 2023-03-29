using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using System;

public static class Serializer
{
    private static string path => "Assets/Saves/save.sav";

    public static void SaveWithoutVersion(SaveData1 saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveData);
        stream.Close();
    } 
    public static void Save(SaveData1 saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        byte[] info = BitConverter.GetBytes(0);
        stream.Write(info, 0, info.Length);

        formatter.Serialize(stream, saveData);
        stream.Close();
    } 
    public static void Save(SaveData2 saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        byte[] info = BitConverter.GetBytes(1);
        stream.Write(info, 0, info.Length);

        formatter.Serialize(stream, saveData);
        stream.Close();
    } 
    public static void Save(SaveData3 saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        byte[] info = BitConverter.GetBytes(2);
        stream.Write(info, 0, info.Length);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static SaveData3 Load()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);        

        SaveData saveData = null;
        int fileVersion = 0;
        try
        {
            saveData = formatter.Deserialize(stream) as SaveData1;
            Debug.Log($"Loading a not versioned save file.");
        }
        catch
        {
            int intSize = sizeof(int);
            Debug.Assert(intSize == 4);

            stream.Position = 0;

            byte[] byteArray = new byte[intSize];
            stream.Read(byteArray, 0, intSize);
            fileVersion = BitConverter.ToInt32(byteArray, 0);
            Debug.Log($"Loading a save file of version {fileVersion}.");
        }

        if (fileVersion == 0)
        {
            Debug.Log($"File Version: {fileVersion}. File is outdated, converting save file to version {fileVersion + 1}.");

            saveData = saveData == null ? formatter.Deserialize(stream) as SaveData1 : (saveData as SaveData1);
            fileVersion++;
        }
        if (fileVersion == 1)
        {
            Debug.Log($"File Version: {fileVersion}. File is outdated, converting save file to version {fileVersion + 1}.");

            saveData = saveData == null ? formatter.Deserialize(stream) as SaveData2 : (SaveData2)(saveData as SaveData1);
            fileVersion++;
        }
        if (fileVersion == 2)
        {
            Debug.Log($"File Version: {fileVersion}. File is up to date.");

            saveData = saveData == null ? formatter.Deserialize(stream) as SaveData3 : (SaveData3)(saveData as SaveData2);
        }
        stream.Close();

        return saveData as SaveData3;
    }
}

[System.Serializable] 
public class SaveData { }

[System.Serializable]
public class SaveData1 : SaveData
{
    public string name;
    public int age;
    public float money;


    public static explicit operator SaveData2(SaveData1 saveData1)
    {
        return new SaveData2()
        {
            name = saveData1.name,
            age = saveData1.age.ToString(),
            money = saveData1.money.ToString(),
        };
    }
}
[System.Serializable]
public class SaveData2 : SaveData
{
    public string name;
    public string age = "";
    public string money;

    public static explicit operator SaveData3(SaveData2 saveData2)
    {
        SaveData3 saveData3 = new SaveData3()
        {
            name = saveData2.name,
            hasPet = false,
            gender = "Not Specified",
        };
        int.TryParse(saveData2.age, out saveData3.age);
        float.TryParse(saveData2.money, out saveData3.money);

        return saveData3;
    }
}

[System.Serializable]
public class SaveData3 : SaveData
{
    public string name;
    public int age;
    public float money;
    public string gender;
    public bool hasPet;
}