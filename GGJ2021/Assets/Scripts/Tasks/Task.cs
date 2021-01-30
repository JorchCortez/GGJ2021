using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "new Task", menuName = "Task")]
public class Task : ScriptableObject
{
    public bool isActive;

    public string title;
    public string description;
    public int goal;

    public int completableGoal;
}
