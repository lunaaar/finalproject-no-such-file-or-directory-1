using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    public GameObject defeatPanel;
    public GameObject victoryPanel;
    public GameObject spawner;
    public Text health;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void Start()
    {
        DefeatPanelOff();
        VictoryPanelOff();
        SpawnerOn();
    }

    public static GameManager instance()
    {
        return _instance;
    }


    public void DefeatPanelOn()
    {
        defeatPanel.SetActive(true);
    }

    public void DefeatPanelOff()
    {
        defeatPanel.SetActive(false);
    }

    public void VictoryPanelOn()
    {
        victoryPanel.SetActive(true);
    }

    public void VictoryPanelOff()
    {
        victoryPanel.SetActive(false);
    }

    public void SpawnerOn()
    {
        spawner.GetComponent<WaveSpawner>().ResetRounds();
        spawner.SetActive(true);
    }

    public void SpawnerOff()
    {
        spawner.SetActive(false);
    }

    public void Restart()
    {
        DefeatPanelOff();
        SpawnerOn();
        health.text = "5";
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
