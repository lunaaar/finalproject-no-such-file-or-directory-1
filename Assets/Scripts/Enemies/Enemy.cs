using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed;

    public int currentHealth;

    public int maxHealth;

    public int moneyValue;

    protected Transform target;

    protected int waypointIndex = 0;

    public TowerShop towerShop;


    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.waypoints[waypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public virtual void takeDamage(int i)
    {
        currentHealth -= i;
        if (currentHealth <= 0)
        {
            towerShop.AddMoney(moneyValue);
            AudioManager.instance().Play("EnemyDeath");
            Destroy(gameObject);
            return;
        }
    }

    public void move()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.01f)
        {
            GetNextWaypoint();
        }
    }


    public virtual void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    public void AddHealth(int i)
    {
        currentHealth += i;
    }

    public void loseHealth(int i)
    {
        currentHealth -= i;
    }

    public void setWaypointIndex(int i)
    {
        waypointIndex = i;
        target = Waypoints.waypoints[waypointIndex];
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            takeDamage(collision.GetComponent<Bullet>().getDamage());
        }
    }

    public void OnParticleCollision(GameObject collision)
    {
        if (collision.tag == "Bullet")
        {
            takeDamage(collision.GetComponent<Bullet>().getDamage()); 
        }
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsOverMaxHealth()
    {
        return currentHealth > maxHealth;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
