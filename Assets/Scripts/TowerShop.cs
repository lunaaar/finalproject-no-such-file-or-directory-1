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

    public GameObject[] buttons;


    public int money;
    public Text moneyText;

    public void Start()
    {
        UpdateMoney(money);
        buttons = GameObject.FindGameObjectsWithTag("ShopButton");
    }



    public void CreateTower(Transform t)
    {
        if (selectedPrefab != null)
        {
            if (selectedPrefab.GetCost() <= money)
            {
                UpdateMoney(money - selectedPrefab.GetCost());

                SpawnTower(selectedPrefab, t);

                selectedPrefab = null;
            }
        }
    }


    public bool TowerSelected()
    {
        return selectedPrefab != null;
    }

    private Tower SpawnTower(Tower tower, Transform transform)
    {
        //UnselectAll();
        selectedPrefab = null;
        return Instantiate(tower, new Vector2(transform.position.x, transform.position.y), transform.rotation);
    }

    private void UpdateMoney(int newMoney)
    {
        money = newMoney;
        moneyText.text = money.ToString();
    }

    public void AddMoney(int newAmount)
    {
        money += newAmount;
        moneyText.text = money.ToString();
    }

    public void SubtractMoney(int subtract)
    {
        money -= subtract;
        moneyText.text = money.ToString();
    }

    public void UnselectAll()
    {
        foreach(GameObject go in buttons)
        {
            go.GetComponent<ImageSelection>().UnSelect();
             
        }
    }

    public void SelectGlass()
    {
        if (glassDefenderPrefab.GetCost() <= money && selectedPrefab != glassDefenderPrefab)
        {
            selectedPrefab = glassDefenderPrefab;
            return;
        }
        else
        {
            selectedPrefab = null;
        }
    }

    public void SelectMcFee()
    {

        if (mcFeePrefab.GetCost() <= money && selectedPrefab != mcFeePrefab)
        {
            selectedPrefab = mcFeePrefab;
            return;
        } 
        else
        {
            selectedPrefab = null;
        }
    }


    public void SelectVast()
    {

        if (vastPrefab.GetCost() <= money && selectedPrefab != vastPrefab)
        {
            selectedPrefab = vastPrefab;
            return;
        }
        else
        {
            selectedPrefab = null;
        }
    }

    public void SelectByte()
    {

        if (byteDefenderPrefab.GetCost() <= money && selectedPrefab != byteDefenderPrefab)
        {
            selectedPrefab = byteDefenderPrefab;
            return;
        }
        else
        {
            selectedPrefab = null;
        }
    }

    public void SelectFirewall()
    {

        if (firewallPrefab.GetCost() <= money && selectedPrefab != firewallPrefab)
        {
            selectedPrefab = firewallPrefab;
            return;
        }
        else
        {
            selectedPrefab = null;
        }
    }

    public void SelectAAVG()
    {

        if (aavgPrefab.GetCost() <= money && selectedPrefab != aavgPrefab)
        {
            selectedPrefab = aavgPrefab;
            return;
        }
        else
        {
            selectedPrefab = null;
        }
    }

    public void SelectMorton()
    {

        if (mortonPrefab.GetCost() <= money && selectedPrefab != mortonPrefab)
        {
            selectedPrefab = mortonPrefab;
            return;
        }
        else
        {
            selectedPrefab = null;
        }
    }

    public int GetMoney()
    {
        return money;
    }

}
