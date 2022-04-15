using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkEnemy : Enemy
{
    public Enemy respawnObject;

    
    public override void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Object.Instantiate(respawnObject, new Vector2(-10.75f, 3.25f), transform.rotation);

            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
    
