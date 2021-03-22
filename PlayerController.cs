using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius; //how big the circle
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        //occurs a set amount of time every second (good for physics)
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {

        if(grounded) {
            doubleJumped = false;
        }

        anim.SetBool("Grounded", grounded);

        if(Input.GetKeyDown(KeyCode.Space) && grounded) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }

         if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded) {
             GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
             doubleJumped = true;
         }

        if(Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if(Input.GetKey(KeyCode.A)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));


        //moving to right
        if(GetComponent<Rigidbody2D>().velocity.x > .1) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //moving to left
        else if(GetComponent<Rigidbody2D>().velocity.x < -.1){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
