using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class TaskManager : MonoBehaviour
{ 
    private InteractibleItem task;
     
    [SerializeField]
    int taskGoal;
    Player player;
    public InformacionInventario Inventario;
    

    public GameObject taskContainer;
    public TextMeshProUGUI taskDescription;
    public TextMeshProUGUI taskTitle;

    public GameObject CardContainer;
    public Image card;
    public Sprite cardSprite;

    public List<Sprite> sprites;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

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


                taskTitle.text = givenTask.title;
                taskContainer.SetActive(true);
                taskDescription.text = givenTask.description;
                taskGoal = givenTask.goal;

                player.ToggleInventory();
                if(givenTask.goal == 3)
                {
                    Debug.Log("Card");
                    StartCoroutine(toggleNote());
                }
                if(givenTask.goal == 2)
                {
                    StartCoroutine(MiniSlideShow());   
                }
                if(givenTask.goal == 5)
                { 
                    SceneManager.LoadScene("Ending", LoadSceneMode.Single);
                }
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
                player.ToggleInventory();
            }
        }
    }

    IEnumerator toggleNote()
    {
        CardContainer.SetActive(true);
        card.sprite = cardSprite;
        Color color = card.color;
            while (color.a < 1.0f)
            {
                color.a += 2 * Time.deltaTime;
                card.color = color; 
            Debug.Log(color.a);
                yield return new WaitForEndOfFrame();
            }
            color.a = 1.0f;
            card.color = color;
            yield return new WaitForSecondsRealtime(5);
            while (color.a >= 0.0f)
            {
                color.a -= 2 * Time.deltaTime;
                card.color = color;
                yield return new WaitForEndOfFrame();
            }
            color.a = 0.0f;
            card.color = color;


        CardContainer.SetActive(false);
        yield return null;
    }

    IEnumerator MiniSlideShow()
    {
        CardContainer.SetActive(true);

        for (int i = 0; i < sprites.Count; i++)
        {
            card.sprite = sprites[i];
            Color color = card.color;
            while (color.a < 1.0f)
            {
                color.a += 1 * Time.deltaTime;
                card.color = color;
                yield return new WaitForEndOfFrame();
            }
            color.a = 1.0f;
            card.color = color;
            yield return new WaitForSecondsRealtime(3);
            while (color.a >= 0.0f)
            {
                color.a -= 1 * Time.deltaTime;
                card.color = color;
                yield return new WaitForEndOfFrame();
            }
            color.a = 0.0f;
            card.color = color;
        }

        CardContainer.SetActive(false);
        yield return null;
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
