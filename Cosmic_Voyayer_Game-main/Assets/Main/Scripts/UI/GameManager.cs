using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GameOver Canvas")]
    public GameObject GameoverCanvas;

    public void LoadsceneTransition()
    {
        GameoverCanvas.SetActive(true);
      
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

   

}
