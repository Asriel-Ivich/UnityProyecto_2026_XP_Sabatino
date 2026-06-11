using UnityEngine;
using System.Collections.Generic;

public class MakeDamageEnemy : MonoBehaviour
{
    public int cantidad = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthSystem>().RecibirDaño(cantidad);

            Debug.Log("HizoDañito");

        }

    }

}
