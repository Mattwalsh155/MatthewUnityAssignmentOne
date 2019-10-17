using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Make a reference to the rigidbody so we can access it
    private Rigidbody2D playerRigidbody;

    // Need a variable to handle the jumping
    public bool isJumping = false;
    public int jumpForce = 100;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void ResetAnimation()
    {
        animator.SetBool("Jumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        //ResetAnimation();

        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            animator.SetBool("Jumping", true);
            isJumping = true;
            //addforce here
            playerRigidbody.AddForce(Vector2.up * jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.name == "Platform")
        {
            isJumping = false;
            animator.SetBool("Jumping", false);
        }
    }

    // to jump we need to AddForce to the rigidbody
    // m_rigidbody.AddForce
}
