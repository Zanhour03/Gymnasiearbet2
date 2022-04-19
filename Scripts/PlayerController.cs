using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float speed;
    private float runSpeed = 5;
    public float turnSpeed;
    private float horizontalInput;
    private float verticalInput;
    public float jumpForce;
    public float gravityModefier;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
       
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        
        Physics.gravity *= gravityModefier;





    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * runSpeed * verticalInput);
            playerAnim.SetInteger("Runing", 1);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerAnim.SetInteger("Runing", 0);

        }
        if (Input.GetKey(KeyCode.W))
        {
            playerAnim.SetInteger("Speed_f", 1);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetInteger("Speed_f", 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            playerAnim.SetInteger("Backwards", 1);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetInteger("Backwards", 0);

        }





    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
