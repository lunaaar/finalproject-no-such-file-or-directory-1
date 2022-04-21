using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootkitEnemyBuff : MonoBehaviour
{

    private GameObject[] buffedEnemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().AddHealth(50);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision.GetComponent<Enemy>().IsOverMaxHealth())
            {
                collision.GetComponent<Enemy>().ResetHealth();
            }
        }
    }
    
}
