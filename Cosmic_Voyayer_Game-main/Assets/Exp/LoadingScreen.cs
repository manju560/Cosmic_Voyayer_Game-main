using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [HideInInspector]
    public int score;
    public static LoadingScreen Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
       
    }
}
