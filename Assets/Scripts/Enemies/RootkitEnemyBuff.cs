using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootkitEnemyBuff : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().AddHealth(10);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().AddHealth(10);
        }

    }
    
}
