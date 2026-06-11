using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;

public class PatrollEnemy : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    public CapsuleCollider rangoAtaque;

    public float speed;

    public NavMeshAgent agente;
    public float distancia_ataque;
    public float radio_vision;


    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > radio_vision)
        {
            agente.enabled = false;
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

           agente.enabled = true;
           agente.SetDestination(target.transform.position);
            
            if (Vector3.Distance(transform.position, target.transform.position)> distancia_ataque && !atacando)
            {
                ani.SetBool("walk",false);
                ani.SetBool("run", true);
            }

            else
            {
                if(!atacando)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);

                }
            }

        }

        if(atacando)
        {
            agente.enabled = false;
        }
    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;

        rangoAtaque.enabled = true;
    }


    void Update()
    {
        Comportamiento_Enemigo();
    }

    private void OnDrawGizmos()
    {
        // Dibuja el rango de vision del enemigo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio_vision);

        // Dibuja la distancia de ataque
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distancia_ataque);
    }

}
/*
public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Comportamiento_Enemigo()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                ani.SetBool("attack", false);
            }

            else
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);

                ani.SetBool("attack", true);
                atacando = true;
            }
            
        }
        
    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;

    }

    void Update()
    {
        Comportamiento_Enemigo();
    }

 
 
 
 
 
 public NavMeshAgent Monstruo;
    public float Velocidad;
    public bool Persiguiendo;
    public float Rango;
    public float Distancia;

    public Transform Objetivo;

    [Header("Animaciones")]
    public Animation Anim;
    //Cambiar nombre de animacion cuendo este lista
    public string Enemy_01_Caminar;
    //Cambiar nombre de animacion cuendo este lista
    public string Enemy_02_Quieto;


    private void Update()
    {
        Distancia = Vector3.Distance(Monstruo.transform.position, Objetivo.position);

        if(Distancia < Rango)
        {
            Persiguiendo = true;
        }

        else if(Distancia > Rango + 3)
        {
            Persiguiendo = false;
        }
        if (Persiguiendo == false)
        {
            Monstruo.speed = 0;
            //Cambiar nombre de animacion cuendo este lista
            Anim.CrossFade(Enemy_02_Quieto);
        }
        else if (Persiguiendo == true)
        {
            Monstruo.speed = Velocidad;

            Anim.CrossFade(Enemy_01_Caminar);

            Monstruo.SetDestination(Objetivo.position);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Rango);
    }
    */