using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "ScriptableObjects/QuestData")]
public class QuestSO : ScriptableObject
{
    public int questID;
    public string questDescription;
    public List<string> itemRequirements;
    public List<string> interactionRequirements;
    public List<string> npcRequirements;
    public QuestSO requiredPriorQuest;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
