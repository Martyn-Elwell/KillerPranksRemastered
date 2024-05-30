using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  //Nicer syntax for finding IDataPersistance Objects
using UnityEditor;

public class DataPersistanceManager : MonoBehaviour
{
    private GameData gameData;

    private List <IDataPersistance> dataPersistanceObjects;

    public static DataPersistanceManager instance { get; private set; }

    private void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene.");
        }

        instance = this;
    }

    private void Start()
    {
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();

    }

    public void NewGame()
    {
        this.gameData= new GameData();
    }

    public void LoadGame()
    {
        ///TODO - LOAD SAVE DATA FROM FILE USING DATA HANDLER

        //if no data can be loaded, initialize a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found, Initializing data to defaults.");
            NewGame();
        }

        //PUSH LOADED DATA TO ALL OTHER SCRIPTS THAT NEED IT
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData); 
        }

        Debug.Log("Loaded Data = " /*+ gameData.Data*/);

    }

    public void SaveGame()
    {
       //PASS DATA TO OTHER SCRIPTS SO THEY CAN UPDATE IT
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved Data = " /*+ gameData.Data*/);

        ///SAVE THAT DATA TO A FILE WITH THE DATA HANDLER
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }

}
