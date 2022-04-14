using System.Collections;
using System.Collections.Generic;
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

    public void setSelectedToGlass()
    {
        selectedPrefab = glassDefenderPrefab;
    }

    public void createTower(Transform t)
    {
        if (selectedPrefab != null)
        {
            spawnTower(selectedPrefab, t);

            selectedPrefab = null;
        }
    }

    public bool towerSelected()
    {
        return selectedPrefab != null;
    }

    private Tower spawnTower(Tower tower, Transform transform)
    {
        print("created");
        return Instantiate(tower, new Vector2(transform.position.x, transform.position.y), transform.rotation);
    }

}
