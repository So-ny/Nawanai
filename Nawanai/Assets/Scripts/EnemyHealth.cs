using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    private Animator anim;
    Rigidbody2D myRigid2D;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigid2D = GetComponent<Rigidbody2D>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < currentHealth)
        {
            currentHealth = health;
            anim.SetTrigger("Attacked");
        }
        
        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            myRigid2D.isKinematic = true;
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }


        

    }


}
