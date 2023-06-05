using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject final;
    public bool ThisActive;

    void Start()
    {
        
    }


    void Update()
    {
        if(ThisActive == true)
        {
            final.SetActive(true);
        }
    }
}
