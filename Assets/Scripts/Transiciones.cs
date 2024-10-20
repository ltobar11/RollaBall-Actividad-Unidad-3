using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour

{
    public GameObject MenuInicio;
    public GameObject MenuOpciones;
    public GameObject MenuControles;

    public void Jugar()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Salir()
    {
        // Cierra la aplicación
        Application.Quit();
    }

    public void Menuopciones()
    {
        MenuInicio.SetActive(false);
        MenuOpciones.SetActive(true);  
    }

    public void Menuprincipal()
    {
        MenuInicio.SetActive(true); 
        MenuOpciones.SetActive(false);  
    }

    public void Menucontroles()
    {
        MenuOpciones.SetActive(false);
        MenuControles.SetActive(true);
    }

    public void volveropciones()
    {
        MenuOpciones.SetActive(true);
        MenuControles.SetActive(false);
    }

}
