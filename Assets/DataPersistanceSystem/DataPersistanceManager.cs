using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  //Nicer syntax for finding IDataPersistance Objects
using UnityEditor;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List <IDataPersistance> dataPersistanceObjects;
    private FileDataHandler dataHandler;

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
        //Application.persistantDataPath is the default Unity persistant data storage path, can change to a custom path - not much need to apparently. 
        //See documentation here for pointer locations and more details: https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName); 
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData= new GameData();
    }

    public void LoadGame()
    {
        //load save data from a file using the data handler
        this.gameData = dataHandler.Load();

        //if no data can be loaded, initialize a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found, Initializing data to defaults.");
            NewGame();
        }

        //push loaded data to all other scripts that need it
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData); 
        }

        ///Remove once data definitely persists
        Debug.Log("Loaded Data = " /*+ gameData.Data*/);
    }

    public void SaveGame()
    {
       //pass data to other scripts so they can update it
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        
        ///remove once data definitely persists
        Debug.Log("Saved Data = " /*+ gameData.Data*/);

        //save that data to a file using the data handler
        dataHandler.Save(gameData); 
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
