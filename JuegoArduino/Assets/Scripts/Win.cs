using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    public GameObject TextoWin;
    public static GameObject TextoWinStatic;
    public GameObject Minimap;
    public static GameObject MinimapStatic;

    // Start is called before the first frame update
    void Start()
    {
        Win.TextoWinStatic = TextoWin;
        Win.TextoWinStatic.gameObject.SetActive(false);

        Win.MinimapStatic = Minimap;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void show()
    {
        Win.TextoWinStatic.gameObject.SetActive(true);
        Win.MinimapStatic.gameObject.SetActive(false);
    }
}
