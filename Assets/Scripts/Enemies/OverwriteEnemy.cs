using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverwriteEnemy : Enemy
{
    public override void takeDamage(float i)
    {
        currentHealth = currentHealth - i;
        if (currentHealth <= 0)
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("Tower");
            int random = Random.Range(0, go.Length);

            go[random].GetComponent<Tower>().IncreaseInterval(10f);


            Destroy(gameObject);
        }
    }
}
