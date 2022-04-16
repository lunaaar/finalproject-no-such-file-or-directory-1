using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Tower tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int getDamage()
    {
        //float damage = tower.damage;
        return tower.damage;
    }
    
}
