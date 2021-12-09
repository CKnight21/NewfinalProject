using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using System.Globalization;
using System;
/* 
 Code Notes!


 */

public class PlayerMovement : MonoBehaviour
{
    
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    bool wallCheck2;
    [SerializeField] Transform wallCheck;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update

   
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        
    }

    public float turnSensitivity = 10;

    // Update is called once per frame
    void Update()
    {
        Camera main = Camera.main;
        GameObject play = GameObject.Find("Player");
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(play.transform.position, Vector3.up, -turnSensitivity * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(play.transform.position, Vector3.up, turnSensitivity * Time.deltaTime);
        }
        float player = GameObject.Find("Player").transform.position.y;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (player < 6.2)
        {
            wallCheck2 = Physics.CheckSphere(wallCheck.position, 1f, ground);
        }
        else
        {
            wallCheck2 = false;
        }
        
        
        rb.velocity = new Vector3((main.transform.right.x * horizontalInput * movementSpeed) + (main.transform.forward.x * verticalInput * movementSpeed), rb.velocity.y, (main.transform.forward.z * verticalInput * movementSpeed) + (main.transform.right.z * horizontalInput * movementSpeed));

        if (Input.GetButtonDown("Jump") && IsGrounded() || Input.GetButtonDown("Jump") && wallCheck2 == true)
        {
            jump();
        }

       
       // GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            jump();
        }
    }

    bool IsGrounded()
    {
        //to check if something is in the radius of another object.
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
        // This allows the player to not be abe to jump in mid air by checking if the player
        // is standing on the ground.
    }

    
}
