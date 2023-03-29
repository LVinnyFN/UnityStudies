using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastVersionLoader : MonoBehaviour
{
    public string myNameString;
    public int ageInt;
    public float moneyFloat;
    public bool hasPetBool;
    public string genderString;

    [ContextMenu("Load")]
    public void Load()
    {
        SaveData3 saveData = Serializer.Load();

        myNameString = saveData.name;
        ageInt = saveData.age;
        moneyFloat = saveData.money;
        genderString = saveData.gender;
        hasPetBool = saveData.hasPet;
    }
}
