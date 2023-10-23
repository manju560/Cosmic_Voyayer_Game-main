using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public List<SpriteRenderer> CircleRenderers;


    private void Start()
    {
        StartCoroutine(loading());
    }

    IEnumerator loading()
    {
        SpriteRenderer currentone;
        foreach(SpriteRenderer i in CircleRenderers)
        {
            currentone = i;
            yield return new WaitForSeconds(1f);
            currentone.color = Color.white;
        }
    }
}
