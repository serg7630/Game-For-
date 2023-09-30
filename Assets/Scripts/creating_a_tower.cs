using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creating_a_tower : MonoBehaviour
{
    public GameObject towerPrefab;

    public Transform spawnPos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("creatTower"))
        {
            //Vector2 PlayerPos;
            //PlayerPos.x = transform.position.x + 1f;
            //PlayerPos.y=transform.position.y + 1f;
            GameObject Tower=Instantiate(towerPrefab,spawnPos.position,Quaternion.identity);
        }
    }
}
