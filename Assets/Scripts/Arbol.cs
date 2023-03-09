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
    public TextMeshPro textoDa�o;
    public void RecibirDa�o(int _da�o)
    {

        MostrarTextoDa�o(_da�o);

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

    void MostrarTextoDa�o(int cantidad)
    {
        textoDa�o.gameObject.SetActive(false);
        textoDa�o.text = cantidad.ToString();
        textoDa�o.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            print("da�o");
            int da�o = collision.GetComponent<Player>().hacha.da�oHacha.valor;
            collision.GetComponent<Player>().hacha.Golpeo();
            RecibirDa�o(da�o);
        }
    }
}
