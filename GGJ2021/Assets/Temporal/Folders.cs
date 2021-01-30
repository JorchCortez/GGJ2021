using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folders : MonoBehaviour
{
    public GameObject Items;

    private GameObject panelInventario;
    private GameObject panelOtro;
    private Animator animator;

    public static Folders Instancia;
    public bool FoldersVisibles { get; set; }
    public bool Ocupado { get; set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instancia == null)
            Instancia = this;
        panelInventario = transform.GetChild(0).gameObject;
        panelOtro = transform.GetChild(1).gameObject;
        animator = GetComponent<Animator>();
        FoldersVisibles = false;
        Ocupado = false;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ocupado && Input.GetKeyDown(KeyCode.Escape))
        {
            if (FoldersVisibles)
                animator.Play("FoldersOff");
            else
                animator.Play("FoldersOn");
            FoldersVisibles = !FoldersVisibles;
            Ocupado = true; Invoke("Desocupar", 1.0f);
        }
        if (FoldersVisibles && !Ocupado && Input.GetKeyDown(KeyCode.E))
        {
            if (panelInventario.transform.GetSiblingIndex() != 0)
            {
                panelInventario.transform.SetSiblingIndex(0);
            }
            else
            {
                panelOtro.transform.SetSiblingIndex(0);
            }
        }
    }

    public void IngresaAInv(string key,Vector3 posicion)
    {
        Ocupado = true;
        var item = Items.transform.Find($"Item ({key})");
        if(item == null)
        {
            Debug.Log($"No se encontró: Item ({key})");
            return;
        }
        panelInventario.transform.SetSiblingIndex(0);
        item.gameObject.SetActive(true);

        RectTransform CanvasRect = transform.parent.GetComponent<RectTransform>();
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(posicion);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
        item.gameObject.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
        item.GetComponent<Item>().SalDelMundo();
    }

    public void FoldersOn()
    {
        animator.Play("FoldersOn");
        FoldersVisibles = true;        
    }

    public void Desocupar()
    {
        Ocupado = false;
    }
}
