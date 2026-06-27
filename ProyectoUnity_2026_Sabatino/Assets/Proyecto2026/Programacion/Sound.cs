using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

// 3.Se tiene que serializar para poderse ver en el inspector -> Isnpetror, luego de Sound
[System.Serializable]
public class Sound
{
    // 1.Inicialisar variables -> Audio Manager

    public string name;

    public AudioClip clip;

    public bool loop;

    // 4.Praa hacer sliders se utiliza range -> Audio Manager
    [Range (0f,1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    // 6.Variable para guardar el audisource que se va a tocar -> Audiomanager
    [HideInInspector]
    public AudioSource source;
}
