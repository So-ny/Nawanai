using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
   public LogicScript logic;

   void Start()
   {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
   }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
        }
        logic.gameOver();

        
    }
    


}
