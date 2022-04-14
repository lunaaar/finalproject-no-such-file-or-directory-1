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
            if (selectedPrefab.getCost() <= money)
            {
                UpdateMoney(money - selectedPrefab.getCost());

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
        return Instantiate(tower, new Vector2(transform.position.x, transform.position.y), transform.rotation);
    }

    private void UpdateMoney(int newMoney)
    {
        money = newMoney;
        moneyText.text = money.ToString();
    }

    public void UnselectAll()
    {
        foreach(GameObject go in buttons)
        {
            if (!go.GetComponent<ImageSelection>().WasClicked())
            {
                go.GetComponent<ImageSelection>().UnSelect();
            } 
        }
    }

    public void SelectGlass()
    {
        if (selectedPrefab == glassDefenderPrefab)
        {
            selectedPrefab = null;
            return;
        }

        if (glassDefenderPrefab.getCost() <= money)
        {
            selectedPrefab = glassDefenderPrefab;
            return;
        }

        
    }

    public void SelectMcFee()
    {

        if (mcFeePrefab.getCost() <= money || selectedPrefab == null)
        {
            selectedPrefab = mcFeePrefab;
            return;
        }

        if (selectedPrefab == mcFeePrefab)
        {
            selectedPrefab = null;
        }
    }


    public void SelectVast()
    {

        if (vastPrefab.getCost() <= money || selectedPrefab == null)
        {
            selectedPrefab = vastPrefab;
            return;
        }

        if (selectedPrefab == vastPrefab)
        {
            selectedPrefab = null;
        }
    }

    public void SelectByte()
    {

        if (byteDefenderPrefab.getCost() <= money || selectedPrefab == null)
        {
            selectedPrefab = byteDefenderPrefab;
            return;
        }

        if (selectedPrefab == byteDefenderPrefab)
        {
            selectedPrefab = null;
        }
    }

    public void SelectFirewall()
    {

        if (firewallPrefab.getCost() <= money || selectedPrefab == null)
        {
            selectedPrefab = firewallPrefab;
            return;
        }

        if (selectedPrefab == firewallPrefab)
        {
            selectedPrefab = null;
        }
    }

    public void SelectAAVG()
    {

        if (aavgPrefab.getCost() <= money || selectedPrefab == null)
        {
            selectedPrefab = aavgPrefab;
            return;
        }

        if (selectedPrefab == aavgPrefab)
        {
            selectedPrefab = null;
        }
    }

    public void SelectMorton()
    {

        if (mortonPrefab.getCost() <= money || selectedPrefab == null)
        {
            selectedPrefab = mortonPrefab;
            return;
        }

        if (selectedPrefab == mortonPrefab)
        {
            selectedPrefab = null;
        }
    }

}
