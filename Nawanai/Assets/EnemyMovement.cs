using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public bool MoveRight;
    float nextTurnTime = 0f;
    public float turnRate = 2f;
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
                MoveRight = false;
            }
            else 
            {
                MoveRight = true;
            }
        }
    }
}
