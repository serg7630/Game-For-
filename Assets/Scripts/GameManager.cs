using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    public GameObject PanelPause;
    public GameObject PauseButom;
    public GameObject  GameOvere;

    public int Levelgame=1;
    public int EnemyCount;


    [SerializeField] TMP_Text level;
    [SerializeField] TMP_Text Enemys;
    void Awake()
    {
        if (S == null) S = this;
        level.text = Levelgame.ToString();
        GameObject[] enem = GameObject.FindGameObjectsWithTag("enemy");
        EnemyCount = enem.Length;
        showEnemyCount();
    }

    
    void Update()
    {
        
    }
    public void gamePause()
    {
        PanelPause.SetActive(true);
        PauseButom.SetActive(false);
        Time.timeScale = 0;
    }
    public void ExitPause()
    {
        PanelPause.SetActive(false);
        PauseButom.SetActive(true);
        Time.timeScale = 1;
    }

    public void DeliteEnemy()
    {
        EnemyCount--;
        showEnemyCount();
    }
    public void AddCountEnemy()
    {
        EnemyCount++;
        showEnemyCount();
    }
    public void showEnemyCount()
    {
        Enemys.text=EnemyCount.ToString();
    }

    public void stopGame()
    {
        GameObject[] enem = GameObject.FindGameObjectsWithTag("enemy");
        foreach (var enemy in enem)
        {
            enemy.GetComponent<enemy>().Gametrue = false;
        }
    }

    public void gameOver()
    {
        GameOvere.SetActive(true);
        Time.timeScale = 0f;
    }
    public void GameStart()
    {
        SceneManager.LoadScene(0);
    }
}
