using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hacha hacha;
    public bool movimiento;
    public bool golpear;

    public float velocidadMovimiento;
    public Animator animator;
    public Transform rootBone;

    float inputX;




    private void Update()
    {
        if(movimiento)
            Mover();

        if(golpear)
            Golpear();

        AnimatorParameters();
    }

    void Golpear()
    {
        if(Input.GetButtonDown("Jump"))
        {
            StartCoroutine(BloquearMovimientoDuranteAnimacion());

            if (hacha.hpHacha.valor > 1)
                animator.Play("Golpear");
            else
                animator.Play("HachaRota");
        }
    }

    void Mover()
    {
        inputX = Input.GetAxisRaw("Horizontal");   

        if(inputX !=0)
        {
            transform.Translate(Vector3.right * inputX * velocidadMovimiento * Time.deltaTime);
            Flip();
        }

    }

    void Flip()
    {
        transform.localScale = inputX > 0? Vector3.one : new Vector3(-1,1,1);
    }

    void AnimatorParameters()
    {
        animator.SetFloat("inputX", Mathf.Abs(inputX));
    }

    IEnumerator BloquearMovimientoDuranteAnimacion()
    {
        movimiento = false;

        while(!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        movimiento = true;
    }






}
