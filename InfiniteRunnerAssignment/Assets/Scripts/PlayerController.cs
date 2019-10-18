using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // reference to GameManager
    public GameManager gameManager;
    // Make a reference to the rigidbody so we can access it
    private Rigidbody2D playerRigidbody;

    // Need a variable to handle the jumping
    public bool isJumping = false;
    public bool isDead = false;
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
        animator.SetBool("Dying", false);
    }

    // Update is called once per frame
    void Update()
    {
        //ResetAnimation();

        if (!gameManager.isPaused)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    gameManager.PauseGame();
                }
                if (Input.GetKey(KeyCode.Space) && isJumping == false)
                {
                    animator.SetBool("Jumping", true);
                    isJumping = true;
                    //addforce here
                    playerRigidbody.AddForce(Vector2.up * jumpForce);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    gameManager.UnpauseGame();
                }
            }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Platform" && isDead == false)
        {
            isJumping = false;
            animator.SetBool("Jumping", false);
        }
        else 
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Dying", true);
        }
        
        if (other.gameObject.tag == "Enemy")
        {
            isDead = true;
            animator.SetBool("Dying", true);
            isJumping = true;
        }

        if (other.gameObject.tag == "Pickup")
        {
            Destroy(other.gameObject);
        }
    }

    // to jump we need to AddForce to the rigidbody
    // m_rigidbody.AddForce
}
