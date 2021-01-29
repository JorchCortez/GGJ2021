using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task : ScriptableObject
{
    public bool isActive;

    public string title;
    public string description; 
}
