using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Enemy ddosEnemyPrefab;
    public Enemy trojanPrefab;
    public Enemy networkPrefab;
    public Enemy polymorphicPrefab;
    public Enemy overwritePrefab;
    public Enemy residentPrefab;

    private int currentRound;
    public float countdown;
    public float timeBetweenWaves;

    public WaveSpawner(Enemy d, Enemy t, Enemy n, Enemy p, Enemy o, Enemy r)
    {
        ddosEnemyPrefab = d;
        trojanPrefab = t;
        networkPrefab = n;
        polymorphicPrefab = p;
        overwritePrefab = o;
        residentPrefab = r;
    }

    private void Awake()
    {
        currentRound = 1;
        countdown = 4f;
        timeBetweenWaves = 5f;
    }

    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;

        }

        countdown -= Time.deltaTime;
    }

    IEnumerator spawnWave()
    {
        for (int i = 0; i < currentRound; i++)
        {
            spawn(ddosEnemyPrefab);
            yield return new WaitForSeconds(0.5f);
        }

        currentRound++;
    }


    private Enemy spawn(Enemy prefab)
    {
        return Object.Instantiate(prefab);
    }
}