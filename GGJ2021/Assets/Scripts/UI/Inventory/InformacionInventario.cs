using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformacionInventario : MonoBehaviour
{
    public List<GameObject> positions;
    public List<InteractibleItem> items;
    public GameObject container;



    // Start is called before the first frame update
    void Start()
    {
        //Items[0].gameObject.SetActive(true);
    }


    public void SetObjectAccquired(InteractibleItem info)
    {
        if (!items.Contains(info))
        {
            items.Add(info);
            Debug.Log(items.Count);
            positions[items.Count - 1].gameObject.SetActive(true); 
            var Item = Instantiate(info.ObjectInventory, positions[items.Count - 1].transform.position, positions[items.Count - 1].transform.rotation);
            Item.transform.SetParent(container.transform);

        }
        else
        {
            Debug.Log("Item already exists");
        }

    }

}
