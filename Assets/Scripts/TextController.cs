using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public GameObject GameOverText;
    public static GameObject GameOverStatic;
    // Start is called before the first frame update
    void Start()
    {
        GameOverStatic = GameOverText;
        GameOverStatic.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void show(){
        GameOverStatic.gameObject.SetActive(true);
    }
}
