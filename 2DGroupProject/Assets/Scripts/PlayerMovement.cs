using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float jumpSpeed = 2f;
    bool grounded = false;
    Rigidbody2D rb;
    Animator anim;
    
    private knockback Knockback;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Knockback = GetComponent<knockback>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!Knockback.IsBeingKnockedBack)
        //{
            float moveX = Input.GetAxis("Horizontal");
            Vector2 velocity = rb.velocity;
            velocity.x = moveX * moveSpeed;
            rb.velocity = velocity;
            //need to find a way to know if we are on the ground
            if (Input.GetButtonDown("Jump") && grounded)
            {
                rb.AddForce(new Vector2(0, 100 * jumpSpeed));
                grounded = false;
            }
            anim.SetFloat("y", velocity.y);
            anim.SetBool("grounded", grounded);
            int x = (int)Input.GetAxisRaw("Horizontal");
            anim.SetInteger("x", x);
            /*if (x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }*/
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
        else if (collision.gameObject.layer == 6)
        {
            grounded = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = false;
        }
    }
}
