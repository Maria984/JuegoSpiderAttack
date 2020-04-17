using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tiempo : MonoBehaviour

{
    float tiempo = 0f;
    public float tiempoInicio = 0;

    int min;
    int sec;

    public bool unaVez = false;

    [SerializeField] Text timer;

    void Start()
    {
        tiempo = tiempoInicio;
    }

    void Update()
    {

        if (unaVez == false)
        {
            tiempo = tiempoInicio;
        }
        if (unaVez == true)
        {
            tiempo -= 1 * Time.deltaTime;
        }

        tiempo -= 1 * Time.deltaTime;

        int min = Mathf.FloorToInt(tiempo / 60);
        int sec = Mathf.FloorToInt(tiempo % 60);

        timer.text = min.ToString("00") + ":" + sec.ToString("00");

        if (tiempo <= 0)
        {
            tiempo = 0;
            Fin.show();
        }
    }

    public void ToggleAnalog()
    {
        unaVez = !unaVez;
    }
}