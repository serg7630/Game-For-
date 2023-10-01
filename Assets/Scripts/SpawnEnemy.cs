using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public static SpawnEnemy S;
    public GameObject Player;

    [SerializeField] GameObject[] enemyPrefabs;

    public float secondSpawn = 1f;

    public bool Spawn;
    void Start()
    {
        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player");
        if (S == null) S = this;

        SpawnGameEnemy();
    }

    public void SpawnGameEnemy()
    {
        //if (!Spawn) return;

        int rng=Random.Range(0,enemyPrefabs.Length);
        GameObject enemy = enemyPrefabs[rng];


        int spawnPos = Random.Range(0, Player.GetComponent<menegerPlayer>().spawnPos.Length);
        GameObject EnemyGO = Instantiate(enemy, Player.GetComponent<menegerPlayer>().spawnPos[spawnPos].transform.position,Quaternion.identity);
        GameManager.S.AddCountEnemy();
        Invoke("SpawnGameEnemy", secondSpawn);
    }
    
    void Update()
    {
        
    }
}
