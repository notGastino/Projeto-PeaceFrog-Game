using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float jumpForce;
    private Rigidbody2D RIG;
    public bool isJumping;
    public bool doubleJump;

    private Animator anim;
    void Start()
    {
        RIG = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        Move();
        Jump();

    }


    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if ((Input.GetAxisRaw("Horizontal")) > 0)
        {

            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if ((Input.GetAxisRaw("Horizontal")) < 0)
        {

            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 180, 0f);
        }

        if ((Input.GetAxisRaw("Horizontal")) == 0)
        {

            anim.SetBool("Run", false);
        }



    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {

            if (!isJumping)
            {
                RIG.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("Jump", true);

            }
            else
            {
                if (doubleJump)
                {
                    RIG.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }

        if (collision.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();

            Destroy(gameObject);
        }


        if (collision.gameObject.tag == "Saw")
        {
            GameController.instance.ShowGameOver();

            Destroy(gameObject);
        }


        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 6)
            {
                isJumping = true;
            }
        }



    }
}