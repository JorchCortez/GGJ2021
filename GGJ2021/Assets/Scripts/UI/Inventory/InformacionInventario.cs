using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InformacionInventario : MonoBehaviour
{
    public List<GameObject> positions;
    public List<InteractibleItem> items;
    public GameObject container;

    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemData;
    public GameObject ItemInfo;



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

            
            Button button = Item.GetComponent<Button>();
            //next, any of these will work: 
            button.onClick.AddListener(delegate { ShowItemData(info); }); 

        }

        else
        {
            Debug.Log("Item already exists");
        }

    }

    public void ShowItemData(InteractibleItem info)
    {
        Debug.Log(info.objectName);
        Debug.Log(info.objectDescription);
         
        itemImage.sprite = info.objectImage;

        itemData.text = info.objectDescription;
        itemName.text = info.objectName;
        ItemInfo.SetActive(true); 
    }


    public void HideItemData()
    {
        ItemInfo.SetActive(false); 
    }

}
