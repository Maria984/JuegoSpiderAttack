using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Recolectar : MonoBehaviour
{
    public AudioSource collectSound;
    public int Puntaje;
    private Animator anim;

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();        
        PuntajeBalas.theScore -= Puntaje;
        Destroy(gameObject);

        if (PuntajeBalas.theScore <= 0)
        {
            Win.show();
            PuntajeBalas.theScore = 0;

        }

    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Spider");
        anim.Play("Spider2");
        anim.Play("Spider3");
    }
}
