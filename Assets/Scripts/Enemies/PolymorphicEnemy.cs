using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphicEnemy : Enemy
{
    public override void takeDamage(int i)
    {
        currentHealth -= i;
        if(speed < 20)
        {
            speed += 3;
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
