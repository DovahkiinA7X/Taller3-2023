using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacha : MonoBehaviour
{

    public IntVariable hpHacha;
    public IntVariable dañoHacha;
    public IntVariable gastoPorGolpe;
    public IntVariable lvlHacha;

    public Sprite hachaNormal, hachaRota;
    public SpriteRenderer spr;
    public AudioClip sonidoHachaRota;
    public AudioSource audioSource;


    public void Golpeo()
    {
        hpHacha.valor -= gastoPorGolpe.valor;
        CheckHachaHP();
    }

    void CheckHachaHP()
    {
        spr.sprite = hpHacha.valor > 0 ? hachaNormal : hachaRota;
        if(hpHacha.valor < 1)
        {
            audioSource.PlayOneShot(sonidoHachaRota);
        }
    }
}
