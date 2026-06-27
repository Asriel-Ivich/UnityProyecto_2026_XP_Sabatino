using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // 2.Se hace un arreglo de sonidos basado en la clase Sound -> Sound
    public Sound[] sounds;

    // 15.Singleton
    public static AudioManager Instance;

    // 5.Se crea una foreach para que haga un audiosource por cada sonido en la lista -> Sound
    void Awake()
    {
        // 16.Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 14.Singleton
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            // 7.Asignar a cada objeto los componentes de Sound
            s.source = gameObject.AddComponent<AudioSource>();
           
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        // 11.Para tocar desde el audio manager
        //Play("NombreDeSonido");
    }

    // 8.Para tocar el sonido
    public void Play (string name)
    {
        // 9.Forma pro de ahorrarte un foreach, necesita usar System
        Sound s = Array.Find(sounds, sound => sound.name == name);
       
        // 12.Evitar errores
        if (s == null)
        {
            Debug.LogWarning("Sonido: " + name + " no encontrado!");
            return;
        }

        // 9.Cont
        s.source.Play();
    }

    // 13.Stop
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sonido: " + name + " no encontrado!");
            return;
        }

        s.source.Stop();
    }

    // 10.Así se llama al audiomanager


    //Mandar llamar audiomanager
    //  AudioManager.Instance.Play("NOMBRECANCION");
    //  AudioManager.Instance.Stop("NOMBRECANCION");
}
