using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphicEnemy : Enemy
{
    public override void takeDamage(int i)
    {
        health -= i;
        if(speed < 20)
        {
            speed += 3;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
