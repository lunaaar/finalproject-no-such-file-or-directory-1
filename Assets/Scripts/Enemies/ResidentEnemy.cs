using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentEnemy : Enemy
{
    public override void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject g in go)
            {
                //alter parameters of all towers
                //need towers to continue
            }

            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];

    }
}
