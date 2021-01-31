using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Player : MonoBehaviour
{
    [Header("Player control")]

    public float speed = 1;
    private bool canMove = true;

    [SerializeField]
    private float defaultPlayerSize = 1;
    float inputX;
    float inputY;

    bool headingRight = false;
    bool canModifySize = true;


    [Header("Tasks")]
    public TaskManager TM; 


    [Header("Interactions")]
    [SerializeField]
    private bool canInteract = false;
    GameObject interactible = null;

    [Header("Menu")]
    public GameObject inventory;

    [Header("Animations")]
    public Animator anim;



    void Start()
    { 
        AlterSizeByPosition();
        anim = gameObject.GetComponent<Animator>();
    }
     
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        canModifySize = inputY >= 0.01 || inputY <= -0.01;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleInventory();
        }

        ShowInteraction();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if(inputX != 0 || inputY != 0)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            Vector3 playerMovement = new Vector3(inputX * speed, inputY * speed, 0.0f);
            transform.position = transform.position + playerMovement * Time.deltaTime;
            SwitchViewSide(); 
            AlterSizeByPosition(); 
        }
    }

    private void AlterSizeByPosition()
    { 
        if (canModifySize)
        { 
                float scaleVariation = -transform.position.y / 30 ;
                Vector3 scaleChange = new Vector3(headingRight ? defaultPlayerSize + scaleVariation : (defaultPlayerSize * -1 - scaleVariation) , defaultPlayerSize + scaleVariation, defaultPlayerSize + scaleVariation);
                transform.localScale = scaleChange;  
        } 
        canModifySize = false;
    }

    private void SwitchViewSide()
    { 
        Vector3 scale;
        scale = transform.localScale;

        if (inputX <= -0.01 ) {
            headingRight = false; 
        }
        else if (inputX >= 0.01)
        {
            headingRight = true; 
        }

        float absoluteVal = Mathf.Abs(transform.localScale.x);
        scale.x = headingRight ? absoluteVal : absoluteVal * -1;
        transform.localScale = scale;


    }

    private void ShowInteraction()
    {
        //TODO:
        //Show the interaction button or something that will give the player the option to interact with an object 
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                SetCurrentTask(interactible); 
            }
        }
    }
 
    private void SetCurrentTask(GameObject interactible)
    {
        if (interactible.GetComponent<TaskHandler>())
        {
            TM.SetCurrentTask(interactible);
        }  
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

    private void ToggleInventory()
    {

        inventory.SetActive(!inventory.activeSelf);
        canMove = !inventory.activeSelf;
    }


}
