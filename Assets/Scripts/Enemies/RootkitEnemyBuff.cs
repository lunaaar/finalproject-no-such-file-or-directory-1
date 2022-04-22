using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootkitEnemyBuff : MonoBehaviour
{

    private List<GameObject> buffedEnemies;

    public void Awake()
    {
        buffedEnemies = new List<GameObject>();
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().AddHealth(50);
        }
    }
    */

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision.GetComponent<Enemy>().IsOverMaxHealth())
            {
                collision.GetComponent<Enemy>().ResetHealth();
                buffedEnemies.Remove(collision.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print(buffedEnemies.Count);
        if (collision.tag == "Enemy" && !(buffedEnemies.Contains(collision.gameObject)))
        {
            collision.GetComponent<Enemy>().AddHealth(50);
            buffedEnemies.Add(collision.gameObject);
        }

    }

}
