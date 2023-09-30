using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    public GameObject PanelPause;
    public GameObject PauseButom;

    public int Levelgame=1;


    [SerializeField] TMP_Text level;
    void Start()
    {
        if (S == null) S = this;
        level.text = Levelgame.ToString();

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

}
