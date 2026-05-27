using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima= 200;

    private int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(int cantidad)
    {
        vidaActual -= cantidad;

        Debug.Log(gameObject.name = "DAMRecibido" + cantidad);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log(gameObject.name + "Morido :c");

        Destroy(gameObject);
    
    }
}
