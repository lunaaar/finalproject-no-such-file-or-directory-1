using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByteDefenderTower : Tower
{
    public int bulletMax;
    private int bulletCount = 0;
    public int bulletHealth;

   public override void shoot()
   {
       if (bulletCount < bulletMax)
       {
       Instantiate(bullet, new Vector3(transform.position.x-1f, transform.position.y, -1f), this.transform.rotation);
       bulletCount += 1;
       Debug.Log("Minion count: " + bulletCount);
       }
   }

   public override void upgrade()
   {
        upgradeCount += 1;
        upgradeCost += upgradeCostIncreaseAmount;
        damage += damageIncreaseAmount;
        fireRate += fireRateIncreaseAmount;
        bulletMax += 1;
   }

   public int getBulletHealth()
   {
       return bulletHealth;
   }

   public void reduceBulletCount()
   {
       bulletCount -= 1;
       Debug.Log("Minion Died");
       Debug.Log("Minion count: " + bulletCount);
   }
}
