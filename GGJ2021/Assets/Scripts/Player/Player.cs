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
    public GameObject taskList;

    [Header("Animations And Effects")]
    public Animator anim;
    AudioSource source; 
    public AudioClip openMenu;
    public AudioClip closeMenu;
    public AudioClip steps;
    public GameObject patio;



    void Start()
    { 
        AlterSizeByPosition();
        anim = gameObject.GetComponent<Animator>();
        source = gameObject.GetComponent<AudioSource>();
    }
     
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        canModifySize = inputY >= 0.01 || inputY <= -0.01;

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleTaskList();
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
                if (!source.isPlaying && patio.gameObject.activeSelf)
                {
                    source.clip = steps;
                    source.Play();
                }
            }
            else
            {
                anim.SetBool("isWalking", false);
                source.Stop();
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

    public void ToggleInventory()
    {
        source.clip = inventory.activeSelf ? closeMenu : openMenu;
        source.loop = false;
        source.Play();
        inventory.SetActive(!inventory.activeSelf);
        canMove = !inventory.activeSelf;
    }


    public void ToggleTaskList()
    {
        taskList.SetActive(!taskList.activeSelf); 
    }


}
