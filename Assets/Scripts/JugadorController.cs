using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class JugadorController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public TMP_Text TextoContador, TextoGanar, TextoTimer;
    public float tiempo, ntiempo;
    public int crono;
    private int next;
    private bool gameover, siglevel;
    private int nivel=1;

    public GameObject PanelGanar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameover = false;
        siglevel = false;
        contador = 0;
        
        setTextoContador();
        PanelGanar.SetActive(false);
        crono = 0;
        ntiempo = 5.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

        // Asignar movimiento al jugador
        rb.AddForce(movimiento*velocidad);
        tiempo -= Time.deltaTime;
        if (tiempo <= 0) {
            Findeljuego();
        }

        
        if (gameover == true)
        {
            ntiempo -= Time.deltaTime;
            
            if (ntiempo <= 0.0f)
            {
                SceneManager.LoadSceneAsync(0);
            }

        }
        else
        {
            setTextoTimer();
            if (siglevel == true)
            {
                TextoGanar.text = "Avanzando al proximo nivel en " + ntiempo.ToString();
                ntiempo -= Time.deltaTime;
                if (ntiempo <= 0.0f)
                {
                    nivel = nivel + 1;
                    ntiempo = 5.0f;
                    siglevel = false;
                    SceneManager.LoadSceneAsync(nivel);
                    
                }

            }
        }
        
    }

    void Findeljuego()

    {
        TextoGanar.text = "Se acabo el tiempo, perdiste!!";
        PanelGanar.SetActive(true);
        gameover = true;
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            setTextoContador();
        }
    }

    void setTextoContador()
    {
        TextoContador.text = "Contador: "+ contador.ToString();
        if( contador >= 10)
        {
            siguientenivel2();
        }
    }

    void siguientenivel2()
    {
        TextoGanar.text = "Ganaste! Felicidades!!";
        PanelGanar.SetActive(true);
        siglevel = true;
    }

    void setTextoTimer()
    {
        crono = (int)tiempo;
        TextoTimer.text = "Tiempo: " + crono;
        
    }

    void SalirJuego()
    {
        // Cierra la aplicación
        Application.Quit();
    }
}
