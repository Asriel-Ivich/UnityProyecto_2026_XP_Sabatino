using UnityEngine;

public class HealthSystemEnemy : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima= 200;

    [SerializeField] private int vidaActual;
    private DamageEffect damageEffect;

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

        //Debug.Log(gameObject.name = "DAMRecibido" + cantidad);

        //Calcula la direccion del ataque
        Vector3 damageDirection = transform.position - GetAttackerPosition();
        damageEffect.ApplyDamageEffect(damageDirection);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private Vector3 GetAttackerPosition()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);
        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("ArmaPlayer"))
                return hit.transform.position;
        }

        return transform.position - Vector3.forward;
    }

    void Morir()
    {
       // Debug.Log(gameObject.name + "Morido :c");

        Destroy(gameObject);

    }
}
