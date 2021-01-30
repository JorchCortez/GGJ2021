using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerT1 : MonoBehaviour
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
        bool CanMove = !(Folders.Instancia.Ocupado || Folders.Instancia.FoldersVisibles);
        inputX = (CanMove) ? Input.GetAxis("Horizontal") : 0;
        inputY = (CanMove) ? Input.GetAxis("Vertical") : 0;
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
        //Debug.Log(canModifySize);
        //Debug.Log(inputY);
        if (canModifySize)
        { 
                float scaleVariation = -transform.position.y / 4 ;
                Vector3 scaleChange = new Vector3(defaultSize + scaleVariation, defaultSize + scaleVariation, defaultSize + scaleVariation);
                //Debug.Log(scaleChange);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string Nombre = collision.gameObject.name;
        if (Nombre.StartsWith("Objeto_"))
        {
            string key = Nombre.Substring(7);
            collision.gameObject.SetActive(false);
            Folders.Instancia.IngresaAInv(key, collision.gameObject.transform.position);
        }
    }



}
