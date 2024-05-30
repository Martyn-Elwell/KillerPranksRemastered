using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    //List data that needs to be saved here
    public int deathCount;

    //constructor
    //values defined here will be the default values when there's no data to load

    public GameData()
    {
        this.deathCount = 0;
    }

}
