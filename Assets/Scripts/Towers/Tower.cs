using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    
    public Transform target;
    [Header("Attributes")]
    public int upgradeCount = 0;
    public int cost = 10;
    public int upgradeCost = 15;
    public int upgradeCostIncreaseAmount = 0;
    public float range = 3f;

    public float fireRate = 1f;
    public float fireRateIncreaseAmount = 0f;
    private float fireCountdown = 0f;
    public float damage = 1;
    public int damageIncreaseAmount = 0;
    private bool isStunned = false;
    public float stunDuration = 2.5f;
    private float stunTimer = 0f;

    [Header("Unity Setup Fields")]
    public GameObject bullet;
    public string enemyTag = "Enemy";

    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.25f);
    }

    void UpdateTarget() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {

        fireCountdown -= Time.deltaTime;
        stunTimer -= Time.deltaTime;

        if (stunTimer <= 0)
        {
            isStunned = false;
        }

        if (!isStunned)
        {

            if (target == null)
            {
                return;
            }
        
            Vector2 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle-90f,Vector3.forward);
            this.transform.rotation = rotation;

        

            if (fireCountdown <= 0f)
            {
                shoot();
                fireCountdown = 1f/ fireRate;
            }

        }
    }

    public virtual void shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0f), this.transform.rotation);
    }

    public virtual void upgrade()
    {
        upgradeCount += 1;
        upgradeCost += upgradeCostIncreaseAmount;
        damage += damageIncreaseAmount;
        fireRate += fireRateIncreaseAmount;
    }

    public void changeDamage(int amount)
    {
        damage -= amount;
    }

    public bool stunTower()
    {
        if (isStunned)
        {
            return false;
        }

        isStunned = true;
        stunTimer = stunDuration;
        return isStunned;
    }

    public int GetCost()
    {
        return cost;
    }

    public float GetDamage()
    {
        return damage;
    }

    public int GetUpgradeCount()
    {
        return upgradeCount;
    }

    public int GetUpgradeCost()
    {
        return upgradeCost;
    }
    
    // Shows range when Gizmos is turned on
    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void IncreaseInterval(float f)
    {
        fireCountdown += f;
    }

    public void DecreaseDamage(float f)
    {
        damage -= f;
    }
}
