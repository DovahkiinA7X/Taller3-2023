using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacha : MonoBehaviour
{
    public int hpHacha;
    public int dañoHacha;
    public int gastoPorGolpe;
    public Sprite hachaNormal, hachaRota;
    public SpriteRenderer spr;

    public void Golpeo()
    {
        hpHacha -= gastoPorGolpe;
        CheckHachaHP();
    }

    void CheckHachaHP()
    {
        spr.sprite = hpHacha > 0 ? hachaNormal : hachaRota;
    }
}
