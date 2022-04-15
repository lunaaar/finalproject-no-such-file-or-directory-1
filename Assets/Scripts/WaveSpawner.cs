using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Enemy ddosEnemyPrefab;
    public Enemy trojanPrefab;
    public Enemy networkPrefab;
    public Enemy polymorphicPrefab;
    public Enemy overwritePrefab;
    public Enemy residentPrefab;
    public Enemy bossPrefab;

    private int currentRound;
    public float countdown;
    public float timeBetweenWaves;

    public Text roundText;

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
    }

    void Update()
    {

        countdown -= Time.deltaTime;
    }

    public void callWave()
    {
        if (countdown <= 0)
        {
            countdown = timeBetweenWaves;
            StartCoroutine(spawnWave());
        }
        
    }

    IEnumerator spawnWave()
    {
        roundText.text = currentRound.ToString();
        for (int i = 0; i < currentRound; i++)
        {
            spawn(ddosEnemyPrefab);
            yield return new WaitForSeconds(0.2f);
        }

        if (currentRound > 3)
        {
            for (int i = 0; i < Mathf.Floor(currentRound / 2); i++)
            {
                spawn(trojanPrefab);
                yield return new WaitForSeconds(0.2f);
            }
        }

        if (currentRound > 7)
        {
            for (int i = 0; i < Mathf.Floor(Mathf.Sqrt(currentRound)); i++)
            {
                spawn(networkPrefab);
                yield return new WaitForSeconds(0.2f);
            }
        }

        if (currentRound > 10)
        {
            for (int i = 0; i < Mathf.Floor(currentRound / 5); i++)
            {
                spawn(polymorphicPrefab);
                yield return new WaitForSeconds(0.2f);
            }
        }

        if (currentRound > 15)
        {
            for (int i = 0; i < Mathf.Floor(currentRound / 15); i++)
            {
                spawn(overwritePrefab);
                yield return new WaitForSeconds(0.2f);
            }
        }

        if (currentRound > 20)
        {
            for (int i = 0; i < Mathf.Floor(currentRound / 4); i++)
            {
                spawn(residentPrefab);
                yield return new WaitForSeconds(0.2f);
            }
        }

        currentRound++;
    }


    private Enemy spawn(Enemy prefab)
    {
        return Object.Instantiate(prefab);
    }

    public void ResetRounds()
    {
        currentRound = 1;
    }
}