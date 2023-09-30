using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int DamageBullet;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject GO=collision.gameObject;
        if (GO.tag == "enemy")
        {
            GO.GetComponent<enemy>().takeDamage(DamageBullet);
        }       

        Destroy(this.gameObject);
    }
}
