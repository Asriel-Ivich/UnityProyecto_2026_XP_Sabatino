using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("Vida")]
    
    public float vidaMaxima= 200;

    //Muestra en el inspector
    [SerializeField] public float vidaActual;
    private DamageEffect damageEffect;

    [Header("Interfaz")]
    public Image BarraSalud;

    #region UI VIDA
    private void Update()
    {
        ActualizarInterfaz();
    }
    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = vidaActual / vidaMaxima;

    }
    #endregion UI VIDA
    void Start()
    {
        vidaActual = vidaMaxima;
        damageEffect = GetComponent<DamageEffect>();
        if (damageEffect == null)
            damageEffect = gameObject.AddComponent<DamageEffect>();
    }

    public void RecibirDaño(int cantidad)
    {
        vidaActual -= cantidad;

        //Calcula la direccion del ataque
        Vector3 damageDirection = transform.position - GetAttackerPosition();
        damageEffect.ApplyDamageEffect(damageDirection);

        if (vidaActual <= 0)
        {
            Morir();
        }

       // Debug.Log(gameObject.name = "DAMRecibido" + cantidad);
    }

    public void CurarVida(int cantidad)
    {
        vidaActual += cantidad;

        if(vidaActual > vidaMaxima )
        {
            vidaActual = vidaMaxima;
        }
    }

    private Vector3 GetAttackerPosition()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);
        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("Enemy"))
                return hit.transform.position;
        }

        return transform.position - Vector3.forward;
    }



    void Morir()
    {
        Debug.Log(gameObject.name + "Morido :c");
        //NOTAAAA Agregar el call de la animacion de muerte
        Destroy(gameObject);
    
    }
}
