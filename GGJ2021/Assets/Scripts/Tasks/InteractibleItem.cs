using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "new Task", menuName = "Task")]
public class InteractibleItem : ScriptableObject
{
    [Header("Informacion del objeto")]
    public string objectName;
    public string objectDescription;
    public Sprite objectImage;
    public GameObject ObjectInventory;

    [Header("Informacion de las tareas")]
    public bool includesTask;
    public string title;
    public string description;
    public int goal;

    public int completableGoal;
}
