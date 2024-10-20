using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jugador;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - jugador.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = jugador.transform.position + offset;
    }
}
