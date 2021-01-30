using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
    [SerializeField]
    Task task;

    public Task GetObjectTask()
    {
        return task;
    }
}
