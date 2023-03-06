using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Arbol : MonoBehaviour
{
    public int hp;
    public UnityEvent onHit, onDead;


    public void RecibirDa�o(int _da�o)
    {
        hp -= _da�o;
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
