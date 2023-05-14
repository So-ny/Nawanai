using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public LogicScript logic;

    //bool crouch = false;

    
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("isJumping", true);
        }

       /* if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }*/
    }

    public void OnLanding()
    {
        anim.SetBool("isJumping", false);
    }

    /*public void OnCrounching(bool isCrouching)
    {
        anim.SetBool("isCrouching", isCrouching);
    }*/

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
            logic.gameOver();
        }
        

        
    }
}
