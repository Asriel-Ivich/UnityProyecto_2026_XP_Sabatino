using UnityEngine;
using System.Collections.Generic;

public class MakeDamage : MonoBehaviour
{
    public int cantidad = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            other.GetComponent<HealthSystemEnemy>().RecibirDaño(cantidad);

            Debug.Log("HizoDañito");

        }

    }

}
