using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventario")]
    public int pociones = 0;
    public int flechas = 0;
    public int antorchas = 0;

    [Header("Pociones")]
    public int curacionPocion = 30;
    public HealthSystem vidaJugador;

    [Header("Antorcha")]
    public GameObject antorchaObjeto;
    

    void Update()
    {
        UsarPocion();
    }

    private void UsarPocion()
    {
        // Tecla Q para usar pocion
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (pociones > 0)
            {
                pociones--;

                vidaJugador.CurarVida(curacionPocion);

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
    }

    public void AgregarFlechas(int cantidad)
    {
        flechas += cantidad;
    }

    public void AgregarAntorchas(int cantidad)
    {
        antorchas += cantidad;
    }

    #region UI
    
    #endregion UI
}
