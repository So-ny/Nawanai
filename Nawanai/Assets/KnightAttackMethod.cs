using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackMethod : MonoBehaviour
{
    public Animator anim;

    public GameObject attackPoint;
	public float radius;
	public LayerMask enemies;
	public float damage;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown("j"))
            {
                Attack();
                nextAttackTime = Time.time +  attackRate;
            }
        }
        
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void attack()
    {
		Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

		foreach(Collider2D enemyGameObject in enemy)
        {
            if(enemyGameObject.tag == "Enemies")
            {
                enemyGameObject.GetComponent<EnemyHealth>().health -= damage;

            }
            else 
            {
                enemyGameObject.GetComponent<BossHealth>().health -= damage;
            }            
        }
    }

	public void OnDrawGizmos()
    {
		Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
