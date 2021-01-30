using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Transform inventario;
    private bool SettingAtInv;
    private bool ExitingWorld;
    private Vector3 destino;
    // Start is called before the first frame update
    void Awake()
    {
        inventario = Folders.Instancia.transform.Find("Inventario");
        SettingAtInv = false;
        ExitingWorld = false;
        destino = new Vector3(-560, 200);
    }

    // Update is called once per frame
    void Update()
    {
        if (SettingAtInv)
        {
            transform.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(transform.GetComponent<RectTransform>().anchoredPosition, destino, 3f);
        }
        else if (ExitingWorld)
        {
            transform.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(transform.GetComponent<RectTransform>().anchoredPosition, Vector2.zero, 3f);
        }
    }

    public void LlamaInventario()
    {
        Folders.Instancia.FoldersOn();
    }

    public void DesocupaFolders()
    {
        Folders.Instancia.Desocupar();
        SettingAtInv = false;
    }

    public void EntraAInventario()
    {
        transform.GetComponent<RectTransform>().SetParent(inventario, false);
        transform.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        ExitingWorld = false;
        SettingAtInv = true;
    }

    public void SalDelMundo()
    {
        ExitingWorld = true;
    }
}
