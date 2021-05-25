using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Controller")]
    public float moveInput;
    public float speed;

    private bool facingRight = true;

    Rigidbody2D rb;

    public static bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    public float jumpForce;


    public int ekstraJumpValue;
    private int ekstraJumps;

    [Header("Audio")]
    AudioSource audioSource;
    public AudioClip Yeah;
    public float pitch;

    [Header("Shooting")]

    public GameObject bullet;
    public Transform shootingPosition;

    private 




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);



        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }




    }

    private void Update()
    {

        

        if (isGrounded == true)
        {
            ekstraJumps = ekstraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && ekstraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            ekstraJumps--;

        }


        else if (Input.GetKeyDown(KeyCode.W) && ekstraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;


        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            pitch = Random.Range(0.9f,1.1f);
            audioSource.PlayOneShot(Yeah);
            audioSource.pitch = pitch;

            Instantiate(bullet, shootingPosition.position, shootingPosition.rotation);
        }

    }
    public void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0);
    }


}



