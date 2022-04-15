using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrojanEnemy : Enemy
{
    public Enemy enemy;

    public void Spawn()
    {
        Object.Instantiate(enemy);
    }

    public override void takeDamage(int i)
    {
        health -= i;
        if(health <= 0)
        {
            Spawn();
            Destroy(gameObject);
        }
    }

}
