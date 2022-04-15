using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public int health;

    protected Transform target;

    protected int waypointIndex = 0;

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
        health -= i;
        if(health <= 0)
        {
            Destroy(gameObject);
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
        health += i;
    }

    public void loseHealth(int i)
    {
        health -= i;
    }

    public void setWaypointIndex(int i)
    {
        waypointIndex = i;
        target = Waypoints.waypoints[waypointIndex];
    }

}
