using UnityEngine;

public class RecoverySystem : MonoBehaviour
{
    public int curacion = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.GetComponent<HealthSystem>())
        {
            other.GetComponent<HealthSystem>().CurarVida(curacion);
        }
    }
}
