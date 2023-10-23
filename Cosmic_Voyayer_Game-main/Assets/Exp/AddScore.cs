using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public void AddScpre()
    {
        LoadingScreen.Instance.score++;
        Debug.Log("1++" + LoadingScreen.Instance.score);
    }
    
    public void AddtwoScpre()
    {
        LoadingScreen.Instance.score+= 2;
        Debug.Log("2++" + LoadingScreen.Instance.score);
    }
}
