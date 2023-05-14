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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            Attack();
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
			enemyGameObject.GetComponent<EnemyHealth>().health -= damage;
        }
    }

	public void OnDrawGizmos()
    {
		Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
