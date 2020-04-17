using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Girar : MonoBehaviour
{
    public float vel;
    public float vel2;

    private int dir;
    private int dir2;

    public float distanciaMov = 50;
    public float salto = 0;

    private int btn1;
    private int btn2;
    private int btn3;

    bool unaVez = false;



    private Animator anim;

    [SerializeField] public GameObject cara;

    SerialPort puerto = new SerialPort("COM4", 9600);

    // Start is called before the first frame update
    void Start()
    {
        puerto.Open();
        puerto.ReadTimeout = 1;

        anim = GetComponent<Animator>(); // Ignora esto, es para que el perro active la animacion al moverse
    }

    
    // Update is called once per frame
    void Update()
    {
        if (puerto.IsOpen)
        {
            try
            {
                mover(puerto.ReadLine());
            }
            catch (System.Exception)
            {

            }
        }


       
        

    }

    void mover(string datoArduino)
    {
        string[] datosArray = datoArduino.Split(char.Parse(","));

        if (datosArray.Length == 5) // La catidad de datos que llegan de arduino
        {
            btn1 = int.Parse(datosArray[0]);
            btn2 = int.Parse(datosArray[1]);
            dir2 = int.Parse(datosArray[2]);
            dir = int.Parse(datosArray[3]);
            btn3 = int.Parse(datosArray[4]);
            print(btn1 + " " + btn2 + " " + dir + " " + dir2 + " " + btn3);
        }
        
        // El orden en que se envian desde arduino, el btn3 es para saltar

        if (btn1 == 1)
         {
             transform.Translate(Vector3.forward * distanciaMov, Space.Self);
             anim.Play("Wolf"); // Active la animacion al moverse
        }

        if (btn2 == 2)
        {
            transform.Translate(Vector3.back * distanciaMov, Space.Self);
            
        }


        if (unaVez == false)
         {
             if (btn3 == 3)
             {
                 transform.Translate(new Vector3(0, salto, 0) * vel) ;
                 unaVez = true;
             }
         }
         if (unaVez == true)
         {
             if (btn3 == 4)
             {
                 transform.Translate(0, 0, 0, Space.Self);
                 unaVez = false;
             }
         }

        // El salto
        /* 
        if (btn3 == 3)
        {
            transform.Translate(0, salto, 0, Space.Self);           
        }

        if (btn3 == 4)
        {
            transform.Translate(0, 0, 0, Space.Self);
        }*/

        // Mueve la cara del personaje de arriba a abajo

        if (dir2 >=3)
        {
            if (dir2 <= 453)
            {
                cara.transform.Rotate(Vector3.right * vel, Space.Self);
            }
        }

        if (dir2 > 653)
        {

            cara.transform.Rotate(Vector3.left * vel, Space.Self);
            
        }

        // Mueve el personaje de izquierda a derecha

        if (dir >= 3)
        {
            if (dir <= 390)
            {
                transform.Rotate(Vector3.down * vel2, Space.Self);
            }
        } // Cuando el valor es entre 253 y 503 el man se queda quieto
        if (dir >= 590)
        {            
                transform.Rotate(Vector3.up * vel2, Space.Self);            
        }
        
        if (btn1 == 0)
        {
            anim.Play(""); // Desactive la animacion al quedarse quieto
        }

    }
}

