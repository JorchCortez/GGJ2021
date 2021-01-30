using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
    [SerializeField]
    InteractibleItem item;

    public InteractibleItem GetItemInfo()
    {
        return item;
    }
}
