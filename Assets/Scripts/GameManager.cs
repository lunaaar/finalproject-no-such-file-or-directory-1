using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    [Header("UI Elements")]
    public GameObject defeatPanel;
    public GameObject victoryPanel;
    public GameObject spawner;
    public Text health;

    [Header("UpgradeMenu")]
    public GameObject upgradeMenu;
    public Text upgradeCostText;
    public Text upgradeCountText;

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
        UpgradeMenuOff();
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

    public void UpgradeMenuOn()
    {
        upgradeMenu.SetActive(true);
    }

    public void UpgradeMenuOff()
    {
        upgradeMenu.SetActive(false);
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
