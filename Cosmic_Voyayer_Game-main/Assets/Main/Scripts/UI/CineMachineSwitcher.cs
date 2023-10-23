using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CineMachineSwitcher : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera Player;
    [SerializeField]
    CinemachineVirtualCamera Enemy;
    bool Playercam = true;
    

    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.C))
        {
            SwitchCam();
        }
    }

    private void SwitchCam()
    {
        if(Playercam)
        {
            Player.Priority = 0;
            Enemy.Priority = 1;
        }
        else
        {
            Player.Priority = 1;
            Enemy.Priority = 0;
        }
        Playercam = !Playercam;
    }
}
