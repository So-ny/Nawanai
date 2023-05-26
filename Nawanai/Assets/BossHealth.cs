using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    private Animator anim;
    Rigidbody2D myRigid2D;
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigid2D = GetComponent<Rigidbody2D>();
        currentHealth = health;
    }

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
            //myRigid2D.isKinematic = true;
            //GetComponent<Collider2D>().enabled = false;
            StartCoroutine(ExecuteAfterTime2());
            this.enabled = false;
        }

        if(health <= 0)
        {
            StartCoroutine(ExecuteAfterTime());
        }
    }
    
    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }


    IEnumerator ExecuteAfterTime2()
    {
        yield return new WaitForSeconds(1.5f);
        myRigid2D.isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
        
    }
}
