using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Arbol : MonoBehaviour
{
    public int hp;
    public UnityEvent onHit, onDead;


    public void RecibirDaño(int _daño)
    {
        hp -= _daño;
        if (hp < 1)
        {
            Muere();           
        } 
        else
        {
            Hit();
        }
    }

    void Hit()
    {
        onHit.Invoke();
    }

    void Muere()
    {
        onDead.Invoke();
    }
}
