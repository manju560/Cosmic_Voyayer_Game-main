using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    public GameObject PauseButton;
    public GameObject JumpButton;
 
    public void PauseMenu()
    {
        PauseMenuPanel.SetActive(true);
        PauseButton.SetActive(false);
        JumpButton.SetActive(false);
        Time.timeScale = 0f;
        
    }

    public void ResumeMenu()
    {
        PauseMenuPanel.SetActive(false);
        PauseButton.SetActive(true);
        JumpButton.SetActive(true);
       Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Backtomenu()
    {
        SceneManager.LoadScene(0);
    }

}
