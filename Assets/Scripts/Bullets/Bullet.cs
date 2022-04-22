using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject tower;
    private Tower towerScript;
    private float damage;

    // Start is called before the first frame update
    void Start()
    {
        towerScript = tower.GetComponent<Tower>();
        damage = towerScript.GetDamage();
    }

    public float getDamage()
    {
        //float damage = tower.damage;
        return damage;
    }
    
}
