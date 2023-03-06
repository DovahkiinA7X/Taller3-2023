using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject hacha;
    public bool movimiento;
    public bool golpear;

    public float velocidadMovimiento;
    public Animator animator;
    public Transform rootBone;

    float inputX;
    bool golpeando;
    float bufferTime = 0.2f;
    float buffer;


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
            if(!golpeando)
            {
                animator.Play("Golpear");
                golpeando = true;
                buffer += bufferTime;
                StartCoroutine(GolpearBuffer());
            }
            else
            {
                buffer += bufferTime;
            }

            
            
            
        }
    }

    void Mover()
    {
        inputX = Input.GetAxis("Horizontal");

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
        animator.SetBool("golpeando", golpeando);
    }

    IEnumerator GolpearBuffer()
    {
        float t = 0;

        while(t < buffer)
        {
            t+= Time.deltaTime;
            yield return null;
        }

        buffer = 0;
        golpeando = false;
        
    }

}
