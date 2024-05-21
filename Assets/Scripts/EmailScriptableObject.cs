using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmailScriptableObject", menuName = "ScriptableObjects/EmailScriptableObject")]
public class EmailScriptableObject : ScriptableObject
{
    public string target = null;
    public string floor = null;
    public string prank = null;
    public string sender = null;
}
