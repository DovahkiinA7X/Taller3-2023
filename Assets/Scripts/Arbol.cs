using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Arbol : MonoBehaviour
{
    public int hp;
    public UnityEvent onHit, onDead, onCaida;
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

    void Caida()
    {
        onCaida.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            print("da�o");
            int da�o = collision.GetComponent<Player>().hacha.da�oHacha;
            collision.GetComponent<Player>().hacha.Golpeo();
            RecibirDa�o(da�o);
        }
    }
}
