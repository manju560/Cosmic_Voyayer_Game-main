using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [Header("Scene Manager")]
    public GameObject SceneTransition;
    private void Awake()
    {
        if (!SceneTransition.activeSelf)
        {
            SceneTransition.SetActive(true);
        }
        SceneTransition.GetComponent<Animator>().Play("Fade In");
    }
    public void Scene()
    {
        if(!SceneTransition.activeSelf)
        {
            SceneTransition.SetActive(true);
        }
        SceneTransition.GetComponent<Animator>().Play("Fade Out");
    }
}
