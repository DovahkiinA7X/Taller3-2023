using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject hacha;
    public int hpHacha;
    public int da�oHacha;
    int gastoHachaPorGolpe;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Arbol"))
        {
            collision.GetComponent<Arbol>().RecibirDa�o(da�oHacha);
            hpHacha -= gastoHachaPorGolpe;

            if (hpHacha < 1)
            {
                SeRompioElHacha();
            }
                
        }
    }

    void SeRompioElHacha()
    {

    }
}
