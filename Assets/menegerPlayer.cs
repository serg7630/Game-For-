using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menegerPlayer : MonoBehaviour
{
    public int Health = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject GO=collision.gameObject;
        print(GO.name);
        if (GO.tag == "enemy")
        {
            
            takeDamage();
            Destroy(GO);
        }
    }
   
    void takeDamage()
    {
        Health--;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
