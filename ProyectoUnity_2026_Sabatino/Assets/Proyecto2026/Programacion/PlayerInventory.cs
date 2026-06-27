using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventario")]
    public int pociones = 0;
    public int flechas = 0;
    public int antorchas = 0;

    [Header("UI TextMeshPro")]
    public TMP_Text pocionesText;
    public TMP_Text flechasText;
    public TMP_Text antorchasText;

    [Header("Pociones")]
    public int curacionPocion = 30;
    public HealthSystem vidaJugador;

    [Header("Antorcha")]
    public GameObject antorchaObjeto;

    void Start()
    {
        ActualizarUI();
    }

    void Update()
    {
        UsarPocion();
    }

    private void UsarPocion()
    {
        // Usa pocion con Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (pociones > 0)
            {
                pociones--;

                if (vidaJugador != null)
                {
                    vidaJugador.CurarVida(curacionPocion);
                }

                ActualizarUI();

                Debug.Log("Usaste una pocion. Pociones restantes: " + pociones);
            }
            else
            {
                Debug.Log("No tienes pociones.");
            }
        }
    }


    public bool UsarFlecha()
    {
        if (flechas > 0)
        {
            flechas--;

            ActualizarUI();

            Debug.Log("Flecha usada. Flechas restantes: " + flechas);
            return true;
        }

        Debug.Log("Sin flechas.");
        return false;
    }

    // recoger objetos
    public void AgregarPociones(int cantidad)
    {
        pociones += cantidad;
        ActualizarUI();
    }

    public void AgregarFlechas(int cantidad)
    {
        flechas += cantidad;
        ActualizarUI();
    }

    public void AgregarAntorchas(int cantidad)
    {
        antorchas += cantidad;
        ActualizarUI();
    }

    #region UI
    public void ActualizarUI()
    {
        if (pocionesText != null)
        {
            pocionesText.text = pociones.ToString();
        }

        if (flechasText != null)
        {
            flechasText.text = flechas.ToString();
        }

        if (antorchasText != null)
        {
            antorchasText.text = antorchas.ToString();
        }
    #endregion UI
    }
}
