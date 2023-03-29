using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject1 : MonoBehaviour
{
    public string nameString;
    public int ageInt;
    public int moneyInt;

    [ContextMenu("Save")]
    public void Save()
    {
        SaveData1 saveData = new SaveData1()
        {
            age = ageInt,
            money = moneyInt,
            name = nameString,
        };
        Serializer.Save(saveData);
    }
    [ContextMenu("Save Without Version")]
    public void SaveWithouVersion()
    {
        SaveData1 saveData = new SaveData1()
        {
            age = ageInt,
            money = moneyInt,
            name = nameString,
        };
        Serializer.SaveWithoutVersion(saveData);
    }

}