using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetector : MonoBehaviour
{
    public Renderer render;

    public Material defaultMat;
    public Material DangerMat;

    public int enemyCount;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.tag == "enemy")
        {
            
            GO.GetComponent<enemy>().inDetector = true;
           
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject GO=collision.gameObject;
        if (GO.tag == "enemy")
        {
            GO.GetComponent<enemy>().ShowMaterial();
            GO.GetComponent<enemy>().ChangeColor=false;
            GO.GetComponent<enemy>().inDetector = true ;
            render.material = DangerMat;
            enemyCount++;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        GameObject GO = collision.gameObject;
        if (GO.tag == "enemy")
        {
            GO.GetComponent<enemy>().inDetector = false;
            GO.GetComponent<enemy>().StelsMaterial();
            enemyCount--;
            if(enemyCount == 0) render.material = defaultMat;
        }
    }

}
