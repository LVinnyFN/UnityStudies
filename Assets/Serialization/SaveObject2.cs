using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject2 : MonoBehaviour
{
    public string nameString;
    public string ageString;
    public string moneyString;

    [ContextMenu("Save")]
    public void Save()
    {
        SaveData2 saveData = new SaveData2()
        {
            age = ageString,
            money = moneyString,
            name = nameString,
        };
        Serializer.Save(saveData);
    }
}