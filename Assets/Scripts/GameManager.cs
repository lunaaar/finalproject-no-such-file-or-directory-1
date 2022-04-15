using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    public Text obtainCountText;
    public GameObject defeatPanel;
    public GameObject spawner;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void DefeatPanelOff()
    {
        defeatPanel.SetActive(false);
    }




}
