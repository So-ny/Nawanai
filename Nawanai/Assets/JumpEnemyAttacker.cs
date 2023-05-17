using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyAttacker : MonoBehaviour
{
    [Header("For Patrolling")]
    public float moveSpeed;
    private float moveDirection = 1;
    private bool facingRight = true;
    public Transform groundCheckPoint;
    public Transform wallCheckPoint;
    public float circleRadius;
    public LayerMask groundLayer;
    private bool checkingGround;
    private bool checkingWall;

    [Header("Other")]
    private Rigidbody2D enemyRB;

    [Header("Jumping")]
    public float jumpHeight;
    public Transform player;
    public Transform groundCheck;
    public Vector2 boxSize;
    private bool isGrounded;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        /*checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);*/
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize,0,groundLayer);
       //Patrolling();
       
    }

    /*void Patrolling()
    {
        if(!checkingGround || checkingWall)
        {
            if(facingRight)
            {
                Flip();
            }
            else if(!facingRight)
            {
                Flip();
            }
        }
        enemyRB.velocity = new Vector2(moveSpeed * moveDirection, enemyRB.velocity.y);
    }*/

    void JumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        if(isGrounded)
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0,180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckPoint.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckPoint.position, circleRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);
    }
}
