using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using TMPro;

public class Arbol : MonoBehaviour
{
    public int hp;
    public UnityEvent onHit, onDead, onCaida;
    public TextMeshPro textoDaño;
    public void RecibirDaño(int _daño)
    {

        MostrarTextoDaño(_daño);

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

    void MostrarTextoDaño(int cantidad)
    {
        textoDaño.gameObject.SetActive(false);
        textoDaño.text = cantidad.ToString();
        textoDaño.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            print("daño");
            int daño = collision.GetComponent<Player>().hacha.dañoHacha.valor;
            collision.GetComponent<Player>().hacha.Golpeo();
            RecibirDaño(daño);
        }
    }
}
