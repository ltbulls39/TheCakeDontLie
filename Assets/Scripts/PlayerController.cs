using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerHealth;


    public CharacterController2D controller;
    public float runSpeed = 30f;
    Animator animator;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;
    }

    public void onLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // Moving character goes here
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (other.gameObject.tag == "Enemy")
            takeDamage();
    }

    private void takeDamage()
    {
        if (playerHealth <= 1)
        {
            playerHealth -= .5f;
            GameObject.Find("ArmPivot").SetActive(false);
            Animator anim = gameObject.GetComponent<Animator>();
            anim.SetBool("ToDestroy", true);
            Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
        }
        else
        {
            playerHealth -= .5f;
        }
    }
}
