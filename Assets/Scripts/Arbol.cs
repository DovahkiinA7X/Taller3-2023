using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Arbol : MonoBehaviour
{
    public int hp;
    public UnityEvent onHit, onDead, onCaida;
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

    void Caida()
    {
        onCaida.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            print("daño");
            int daño = collision.GetComponent<Player>().hacha.dañoHacha;
            collision.GetComponent<Player>().hacha.Golpeo();
            RecibirDaño(daño);
        }
    }
}
