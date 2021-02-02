using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    ExitGame eg;

    private void Awake()
    {
        eg = gameObject.GetComponent<ExitGame>();
    }
    void Update()
    {
        if (Input.anyKey)
        {
            if (!Input.GetKey(KeyCode.Escape) && !eg.ExitMenu.activeSelf)
            { 
                SceneManager.LoadScene("Intro", LoadSceneMode.Single);
            }
        }
    } 
}
