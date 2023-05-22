using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_jump : MonoBehaviour
{
    public float jumpForce = 10f;
    Rigidbody2D rb;

    public float speed;

    public bool MoveRight;
    float nextTurnTime = 0f;
    public float turnRate = 2f;
    float nextJumpTime = 0f;
    public float jumpRate;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2(1,1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2(-1,1);

        }

        if(Time.time >= nextTurnTime)
        {
            if(MoveRight)
            {
                MoveRight = false;
            }
            else 
            {
                MoveRight = true;
            }
            nextTurnTime = Time.time + turnRate;
        }
        if(Time.time >= nextJumpTime)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            nextJumpTime = Time.time + jumpRate;
        }
        if(GetComponent<EnemyHealth>().health <= 0)
        {
            speed = 0f;
            //rb.isKinematic = true;
            jumpForce = 0f;
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            //jumpRate = 0f;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Border")
        {
            if(MoveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0,0);
                transform.localScale = new Vector2(1,1);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0,0);
                transform.localScale = new Vector2(-1,1);

            }
        }
    }
}
