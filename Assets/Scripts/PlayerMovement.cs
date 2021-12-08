using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [SerializeField] float RotationSpeed = 1;
    public float rotX;
    public float rotY;
    public float rotZ;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded() || Input.GetButtonDown("Jump") && wallCheck2 == true)
        {
            jump();
        }

        rotX -= Input.GetAxis("Mouse Y") * Time.deltaTime * RotationSpeed;
        rotY += Input.GetAxis("Mouse X") * Time.deltaTime * RotationSpeed;

        transform.rotation = Quaternion.Euler(0, rotY, 0);
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
