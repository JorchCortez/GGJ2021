using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TaskManager : MonoBehaviour
{ 
    private InteractibleItem task;

    [SerializeField]
    string taskTitle;
    [SerializeField]
    string taskDescription;
    [SerializeField]
    int taskGoal;

    public InformacionInventario Inventario;


    public void SetCurrentTask(InteractibleItem givenTask)
    {
        Inventario.SetObjectAccquired(givenTask);

        if (givenTask.includesTask)
        { 
            if (givenTask.completableGoal == 0 || givenTask.completableGoal == taskGoal)
            {
                task = givenTask;

                SetTaskGoal(givenTask.goal);

                taskTitle = givenTask.title;
                taskDescription = givenTask.description;
                taskGoal = givenTask.goal;
            }
            else
            {
                Debug.Log("this is not the next task");
            }
        }
    }

    private void SetTaskGoal(int goal)
    {
        switch (goal)
        {
            default:
                Debug.Log("this taks");
                return;
                
        }
    } 


    public bool CompleteTaks(int goal)
    {
        if(taskGoal == goal)
        { 
            return true;
        }
        else
        {
            return false;
        }

         
    }


}
