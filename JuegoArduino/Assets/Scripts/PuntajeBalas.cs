﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeBalas : MonoBehaviour
{

    public GameObject scoreText;
    public static int theScore = 10;
 

    void Update()
    {
           scoreText.GetComponent<Text>().text = "x" + theScore;
   
    }
}
