using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    private Tower selectedPrefab;

    public Tower glassDefenderPrefab;
    public Tower mcFeePrefab;
    public Tower vastPrefab;
    public Tower byteDefenderPrefab;
    public Tower firewallPrefab;
    public Tower aavgPrefab;
    public Tower mortonPrefab;

    public int money;
    public Text moneyText;

    public void Start()
    {
        updateMoney(money);
    }

    public void setSelectedToGlass()
    {
        if (glassDefenderPrefab.getCost() <= money)
        {
            selectedPrefab = glassDefenderPrefab;
        }
    }

    public void createTower(Transform t)
    {
        if (selectedPrefab != null)
        {
            if (selectedPrefab.getCost() <= money)
            {
                updateMoney(money - selectedPrefab.getCost());

                spawnTower(selectedPrefab, t);

                selectedPrefab = null;
            }
        }
    }

    public bool towerSelectable()
    {
        return selectedPrefab != null;
    }

    private Tower spawnTower(Tower tower, Transform transform)
    {
        print("created");
        return Instantiate(tower, new Vector2(transform.position.x, transform.position.y), transform.rotation);
    }

    private void updateMoney(int newMoney)
    {
        money = newMoney;
        moneyText.text = money.ToString();
    }

}
