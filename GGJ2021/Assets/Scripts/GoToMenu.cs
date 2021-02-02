using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Title", LoadSceneMode.Single);
        }
    }
}
