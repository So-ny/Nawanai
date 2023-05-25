using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    void Update()
    {
        if(GetComponent<EnemyHealth>().health <= 0)
        {
            StartCoroutine(ExecuteAfterTime());
        }
    }
    
    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
