using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class creating_a_tower : MonoBehaviour
{
    public static creating_a_tower S;

    public GameObject towerPrefab;

    public Transform spawnPos;

    public int countEnemy;

    public int SecondSpawnTower;
    public int CountTower;
    [SerializeField] TMP_Text Tower;


    void Start()
    {
        if (S == null) S = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("creatTower"))
        {
            if (CountTower == 0)
            {
                return;
            }
            DelCountTower();
            //Vector2 PlayerPos;
            //PlayerPos.x = transform.position.x + 1f;
            //PlayerPos.y=transform.position.y + 1f;
            GameObject Tower=Instantiate(towerPrefab,spawnPos.position,Quaternion.identity);
        }
    }

    public void AddCountTower()
    {
        CountTower++;
        ShowTowerCount();
    }
    public void DelCountTower()
    {
        CountTower--;
        //if (CountTower == 0) Invoke("AddCountTower", SecondSpawnTower);
        ShowTowerCount();
    }
    public void ShowTowerCount()
    {
        Tower.text = CountTower.ToString();
    }

    public void addTowerForEnemy()
    {
        countEnemy++;
        if (countEnemy >= 10)
        {
            countEnemy = 1;
            AddCountTower();
        }
    }
}
