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


    public void SetCurrentTask(GameObject interactible)
    {
        InteractibleItem givenTask = interactible.GetComponent<TaskHandler>().GetItemInfo();

        if (givenTask.includesTask)
        { 
            if ((givenTask.completableGoal == 0 && taskGoal < 1 ) || givenTask.completableGoal == taskGoal)
            {

                if (interactible.GetComponent<InteractionHandler>())
                {
                    interactible.GetComponent<InteractionHandler>().Colorize();
                }
                Inventario.SetObjectAccquired(givenTask);
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
        else
        { 
            Inventario.SetObjectAccquired(givenTask);
            if (interactible.GetComponent<InteractionHandler>())
            {
                interactible.GetComponent<InteractionHandler>().Colorize();
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
