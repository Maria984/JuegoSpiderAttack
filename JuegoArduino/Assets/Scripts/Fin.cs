using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{

    public GameObject TextoFin;
    public static GameObject TextoFinStatic;
    public GameObject Minimap;
    public static GameObject MinimapStatic;
    
    // Start is called before the first frame update
    void Start()
    {
        Fin.TextoFinStatic = TextoFin;
        Fin.TextoFinStatic.gameObject.SetActive(false);

        Win.MinimapStatic = Minimap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void show()
    {
        Fin.TextoFinStatic.gameObject.SetActive(true);
        Win.MinimapStatic.gameObject.SetActive(false);
    }
}
