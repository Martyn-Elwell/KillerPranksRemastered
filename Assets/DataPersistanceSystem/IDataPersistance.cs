using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//To let a script save and load data, implement interface IDataPersistance after monobehaviour in a script that requires it.
//Then add the methods defined in IDataPersistance.

//eg: 

/*private void LoadData(GameData data) 
{
    this.deathCount = data.deathCount;
}

private void SaveData(GameData data)
{
    data.deathCount = this.deathCount;
}*/

public interface IDataPersistance
{
    void LoadData(GameData data);

    void SaveData(ref GameData data);
}