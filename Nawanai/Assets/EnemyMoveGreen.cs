using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveGreen : MonoBehaviour
{
    public float speed;

    public bool MoveRight;
    public bool move = true;
    //public float stopRate = 2f;
    float stopTime = 0f;
    float ran;
    float nextTurnTime = 0f;
    //public float turnRate = 2f;
    public float rate = 2f;
    // Update is called once per frame

    void Update()
    {

        if(move)
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
                nextTurnTime = Time.time + rate;          
            }
        }
        if(Time.time >= stopTime)
        {
            if(move)
            {
                move = false;
            }
            else 
            {
                move = true;
            }
            stopTime = Time.time + rate;
        }
 


        if(GetComponent<EnemyHealth>().health <= 0)
        {
            speed = 0f;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Border")
        {
            if(MoveRight)
            {
                Debug.Log("hit");
                transform.Translate(2 * Time.deltaTime * speed, 0,0);
                transform.localScale = new Vector2(1,1);
            }
            else
            {
                Debug.Log("Hit2");
                transform.Translate(-2 * Time.deltaTime * speed, 0,0);
                transform.localScale = new Vector2(-1,1);

            }
        }
    }

}
