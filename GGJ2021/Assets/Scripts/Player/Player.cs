using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player control")]

    public float speed = 1;

    [SerializeField]
    private float defaultPlayerSize = 1;
    float inputX;
    float inputY;

    bool headingRight = true;
    bool canModifySize = true;


    [Header("Tasks")]
    public TaskManager TM;
    InteractibleItem task;

    [Header("Interactions")]
    [SerializeField]
    private bool canInteract = false;
    GameObject interactible = null;


    void Start()
    {
        defaultPlayerSize = transform.localScale.x;

        transform.localScale = new Vector3(defaultPlayerSize, defaultPlayerSize, defaultPlayerSize);

    }
     
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        canModifySize = inputY >= 0.01 || inputY <= -0.01;


        ShowInteraction();
    }

    private void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(inputX * speed, inputY * speed, 0.0f);
        transform.position = transform.position + playerMovement * Time.deltaTime;
        SwitchViewSide(); 
        AlterSizeByPosition();
    }

    private void AlterSizeByPosition()
    { 
        if (canModifySize)
        { 
                float scaleVariation = -transform.position.y / 15 ;
                Vector3 scaleChange = new Vector3(defaultPlayerSize + scaleVariation, defaultPlayerSize + scaleVariation, defaultPlayerSize + scaleVariation);
                transform.localScale = scaleChange;  
        } 
        canModifySize = false;
    }

    private void SwitchViewSide()
    {
        if (inputX < 0 && !headingRight || inputX > 0 && headingRight) {
            headingRight = !headingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

    }

    private void ShowInteraction()
    {
        //TODO:
        //Show the interaction button or something that will give the player the option to interact with an object 
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.M))
            { 
                SetCurrentTask(interactible); 
            }
        }
    }
 
    private void SetCurrentTask(GameObject interactible)
    {
        if (interactible.GetComponent<TaskHandler>())
        {
            InteractibleItem interaction = interactible.GetComponent<TaskHandler>().GetItemInfo();
            TM.SetCurrentTask(interaction);
        }
        Debug.Log("Interacted with" + interactible.gameObject.name);
        
    }

    
    /*Unity Functions*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactible")
        {
            interactible = other.gameObject;

            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactible")
        {
            interactible = null;
            canInteract = false;
        }
    }


}
