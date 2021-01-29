using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;
    [SerializeField]
    private float defaultSize = 1;
    float inputX;
    float inputY;

    bool headingRight = true;
    bool canModifySize = true;

    // Start is called before the first frame update
    void Start()
    {
        defaultSize = transform.localScale.x;

        transform.localScale = new Vector3(defaultSize, defaultSize, defaultSize);

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        canModifySize = inputY >= 0.01 || inputY <= -0.01;
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
        Debug.Log(canModifySize);
        Debug.Log(inputY);
        if (canModifySize)
        { 
                float scaleVariation = -transform.position.y / 4 ;
                Vector3 scaleChange = new Vector3(defaultSize + scaleVariation, defaultSize + scaleVariation, defaultSize + scaleVariation);
                Debug.Log(scaleChange);
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

}
