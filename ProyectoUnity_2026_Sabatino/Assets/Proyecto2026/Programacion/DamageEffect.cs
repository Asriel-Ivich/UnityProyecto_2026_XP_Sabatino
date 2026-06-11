using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageEffect : MonoBehaviour
{
    [Header("Efectos de Daño")]
    [SerializeField] private float flashDuration = 0.1f;
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float knockbackDuration = 0.2f;

    private Material[] originalMaterials;
    private Material[] flashMaterials;
    private Renderer[] renderers;
    private Coroutine flashCoroutine;
    private Coroutine knockbackCoroutine;
    private Rigidbody rb;
    private CharacterController characterController;
    private NavMeshAgent navMeshAgent;
    private bool isKnockbacking = false;

    void Start()
    {
        // Obtiene todos los renders
        renderers = GetComponentsInChildren<Renderer>();
        originalMaterials = new Material[renderers.Length];
        flashMaterials = new Material[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            originalMaterials[i] = renderers[i].material;
            flashMaterials[i] = new Material(originalMaterials[i]);
            flashMaterials[i].color = flashColor;
        }

        // Intenta obtener Rigidbody 
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    public void ApplyDamageEffect(Vector3 damageDirection)
    {
        // Efecto de parpadeo
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);
        flashCoroutine = StartCoroutine(FlashEffect());

        // Efecto de retroceso
        if (knockbackCoroutine != null)
            StopCoroutine(knockbackCoroutine);
        knockbackCoroutine = StartCoroutine(KnockbackEffect(damageDirection));
    }

    private IEnumerator FlashEffect()
    {
        // Cambia materiales 
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = flashMaterials[i];
        }

        yield return new WaitForSeconds(flashDuration);

        // Regresa materialkes originales
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = originalMaterials[i];
        }

        flashCoroutine = null;
    }

    private IEnumerator KnockbackEffect(Vector3 direction)
    {
        if (isKnockbacking) yield break;
        isKnockbacking = true;

        bool hadNavMeshAgent = navMeshAgent != null && navMeshAgent.enabled;
        if (hadNavMeshAgent)
        {
            navMeshAgent.enabled = false; // Desactiva
        }

        float elapsedTime = 0;
        Vector3 knockbackDir = direction.normalized;
        knockbackDir.y = 0.5f; // Pequeño componente vertical para simular impacto

        if (rb != null)
        {
            // Si tiene Rigidbody
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(knockbackDir * knockbackForce, ForceMode.Impulse);

            while (elapsedTime < knockbackDuration)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        else if (characterController != null)
        {
            // Si tiene CharacterController (como el jugador)
            Vector3 originalPosition = transform.position;
            Vector3 targetPosition = originalPosition + knockbackDir * knockbackForce * 0.5f;

            while (elapsedTime < knockbackDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / knockbackDuration;
                // Movimiento suave con easing
                transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
                yield return null;
            }
        }

        //REACTIVA MESHAGENT
        if (hadNavMeshAgent)
        {
            // Esperar un frame para asegurar que el movimiento terminó
            yield return null;
            navMeshAgent.enabled = true;

            // Opcional: Restablecer la posición del agente para que coincida con la nueva posición
            navMeshAgent.Warp(transform.position);
        }
        isKnockbacking = false;
        knockbackCoroutine = null;
    }

    void OnDestroy()
    {
        // Limpiar materiales creados dinámicamente
        for (int i = 0; i < flashMaterials.Length; i++)
        {
            if (flashMaterials[i] != null)
                Destroy(flashMaterials[i]);
        }
    }


}
