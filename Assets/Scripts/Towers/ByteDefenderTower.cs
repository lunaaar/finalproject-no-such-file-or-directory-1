using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByteDefenderTower : Tower
{
    public int bulletMax;
    private int bulletCount = 0;
    public int bulletHealth;

    //private List<GameObject> test = new List<GameObject>(10);

   public override void shoot()
   {
       
       //if (test.Count < bulletMax)
       //{
        Instantiate(bullet, target.position, Quaternion.identity);
        //bulletCount += 1;
        //Debug.Log("Minion count: " + test.Count);
       //}
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
      // Debug.Log("Minion Died");
      // Debug.Log("Minion count: " + bulletCount);
   }
}
