using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject3 : MonoBehaviour
{
    public string nameString;
    public int ageInt;
    public float moneyFloat;
    public string genderString;
    public bool hasPetBool;

    [ContextMenu("Save")]
    public void Save()
    {
        SaveData3 saveData = new SaveData3()
        {
            age = ageInt,
            money = moneyFloat,
            name = nameString,
            gender = genderString,
            hasPet = hasPetBool,
        };
        Serializer.Save(saveData);
    }
}