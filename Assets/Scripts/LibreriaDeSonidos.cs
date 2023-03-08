using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sonidos/Libreria")]
public class LibreriaDeSonidos : ScriptableObject
{
    public AudioClip[] sonidos;

    public AudioClip clip
    {
        get { return sonidos[Random.Range(0, sonidos.Length)]; }
    }

}
