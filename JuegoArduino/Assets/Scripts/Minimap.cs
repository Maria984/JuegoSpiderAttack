using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform jugador;
    // Start is called before the first frame update
    void LateUpdate()
    {
        Vector3 newPosition = jugador.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, jugador.eulerAngles.y, 0f);
    }

}
