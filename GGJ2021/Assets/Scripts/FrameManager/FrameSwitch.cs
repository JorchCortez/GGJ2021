using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{

    public GameObject firstFrame;
    public GameObject nextFrame; 

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            if (firstFrame.activeSelf)
            { 
                firstFrame.SetActive(false);
                nextFrame.SetActive(true);
            } 
        }
    }
}
