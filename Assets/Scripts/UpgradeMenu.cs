using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    private GameObject tower;
    public TowerShop shop;

    [Header("UpgradeMenu")]
    public Text upgradeCostText;
    public Text upgradeCountText;


    public void setText()
    {
        upgradeCountText.text = "Upgrade Count: " + tower.GetComponent<Tower>().GetUpgradeCount();
        upgradeCostText.text = "Upgrade Cost: " + tower.GetComponent<Tower>().GetUpgradeCost();
    }


    public void UpgradeTower()
    {
        print(tower == null);
        if (shop.GetMoney() >= tower.GetComponent<Tower>().GetUpgradeCost())
        {
            shop.SubtractMoney(tower.GetComponent<Tower>().GetUpgradeCost());
            tower.GetComponent<Tower>().upgrade();
            setText();
        }

    }

    public void SetTower(GameObject t)
    {
        tower = t;
    }
}
