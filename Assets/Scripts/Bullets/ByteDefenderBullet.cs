using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByteDefenderBullet : MonoBehaviour {
    
    public GameObject attackEffect;
    public GameObject tower;
    private ByteDefenderTower towerScript;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        towerScript = tower.GetComponent<ByteDefenderTower>();
        health = towerScript.getBulletHealth();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Instantiate(attackEffect, new Vector3(transform.position.x, transform.position.y, -1f), this.transform.rotation);
            health -= 1;
        }

        if (health <= 0)
        {
            towerScript.reduceBulletCount();
            Destroy(gameObject);
            return;
        }
    }
}
