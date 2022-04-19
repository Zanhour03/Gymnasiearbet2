using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveForward : MonoBehaviour
{
    
    public float speed = 0.3f;
    private Animator playerAnim;
    public float enemyHealth = 100f;
    public NavMeshAgent enemy;
    public Transform Player;
    public bool debug = true;
    public bool gameOver;


    // Start is called before the first frame update


    void Start()
    {
        playerAnim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);

       
        if (speed == 0.3 && !gameOver)
        {
            playerAnim.SetInteger("Walk", 1);
            
        }
       else if (speed == 0 )
        {
            playerAnim.SetInteger("Walk", 0);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            transform.Translate(1f * speed * Time.deltaTime, 0f, 0f);
            playerAnim.SetInteger("Attack", 2);
           
        }
    
        if (collision.gameObject.CompareTag("Hit"))
        {

            this.enemyHealth -= 10;

        }
     
        

        if (enemyHealth <= 0 && gameObject.CompareTag("Enemy"))
        {
            playerAnim.SetBool("Death", true);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(gameObject, 3);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAnim.SetInteger("Attack", 0);
            playerAnim.SetInteger("Walk", 1);


        }
    }
}
