using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortonTower : Tower
{
    public override void shoot()
    {
        Instantiate(bullet, target.position, this.transform.rotation);
    }
}
