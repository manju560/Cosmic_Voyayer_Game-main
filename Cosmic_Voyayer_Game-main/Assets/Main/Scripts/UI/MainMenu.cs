using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Title;
    public GameObject Start;
    public GameObject exit;
    public AnimationManager animationManager;

    public void StartGame()
    {
        StartCoroutine(fadeout());
        
    }
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator fadeout()
    {
        animationManager.Scene();
       
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
