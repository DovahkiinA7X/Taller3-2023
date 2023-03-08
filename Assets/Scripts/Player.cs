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
    bool golpeando;
    float bufferTime = 0.3f;
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
            animator.Play("Golpear"); 
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






}
