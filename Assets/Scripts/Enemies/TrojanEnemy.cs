using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrojanEnemy : Enemy
{
    public Enemy enemy;

    public void Spawn()
    {
        Enemy go = Instantiate(enemy, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        go.setWaypointIndex(waypointIndex);
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

    public void OnMouseEnter()
    {
        takeDamage(1);
    }
}
