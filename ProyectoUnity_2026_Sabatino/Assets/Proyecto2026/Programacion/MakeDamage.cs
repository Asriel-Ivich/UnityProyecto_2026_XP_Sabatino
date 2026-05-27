using UnityEngine;
using System.Collections.Generic;

public class MakeDamage : MonoBehaviour
{
    public int cantidad = 10;

    private void OnTriggerEnter(Collider other)
    {
        HealthSystem vida = other.GetComponent<HealthSystem>();

        if(vida!= null)
        {
            vida.RecibirDaño(cantidad);
        }
    }

}
