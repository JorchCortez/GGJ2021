using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{

    public GameObject ExitMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleQuit();
        }
        
    }

    private void ToggleQuit()
    {
        ExitMenu.SetActive(!ExitMenu.activeSelf);
    }

    public void Cancel()
    {
        ToggleQuit();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
