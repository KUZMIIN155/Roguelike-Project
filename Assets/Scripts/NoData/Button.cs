using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    GameObject button;

    public void Start() 
    {
        button = GameObject.Find ("Button");
    }
    
    public void ButtonClicked() 
    {
        button.SetActive(false);   
    }
}
