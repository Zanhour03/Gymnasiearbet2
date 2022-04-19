using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    bool isEven = false;
    public bool debug = true;
    public float Health = 100f;
    public bool gameOver;
    private Animator playerAnim;
    float timeColliding;
    private bool collided;

    // Start is called before the first frame update
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Health <= 0)
        {
            playerAnim.SetBool("PlayerDeath", true);
            gameOver = true;
        }
       


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy started colliding with player.");


         
                    //reduce health here
                    this.Health -= 10;
               
           

        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy is colliding with player.");

            
            var timeSpan = DateTime.Now;
            if (timeSpan.Second % 1.5 == 0)
            {
                if (isEven == false)
                {
                    //reduce health here
                    this.Health -= 10;
                }
                isEven = true;
            }
            else
            {
                isEven = false;
            }



        }
        



    }

}



