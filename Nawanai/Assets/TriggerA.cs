using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerA : MonoBehaviour
{
    ParticleSystem effect;
    
    // Start is called before the first frame update
    void Start()
    {
        effect = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemies")
        {
            effect.Play();
        }
        
    }
}
