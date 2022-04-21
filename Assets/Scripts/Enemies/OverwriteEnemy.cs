using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverwriteEnemy : Enemy
{
    public override void takeDamage(int i)
    {
        currentHealth -= i;
        if (currentHealth <= 0)
        {
            /*
             * Code for stunning towers probably by increasing attack intervals
             * 
             * Require towers to complete
             * 
             */


            Destroy(gameObject);
        }
    }
}
