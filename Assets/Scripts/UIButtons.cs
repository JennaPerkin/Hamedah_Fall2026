using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
