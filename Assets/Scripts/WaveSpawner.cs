using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy ddosEnemyPrefab;
    public Enemy trojanPrefab;
    public Enemy networkPrefab;
    public Enemy polymorphicPrefab;
    public Enemy overwritePrefab;
    public Enemy residentPrefab;
    public Enemy bossPrefab;

    [Header("Tower Reference")]
    public TowerShop towerShop;

    [Header("Round Information")]
    private int currentRound;
    public float countdown;
    public float timeBetweenWaves;

    [Header("Round UI")]
    public Text roundText;
    public GameObject roundButton;
    private bool selectable;

    public WaveSpawner(Enemy d, Enemy t, Enemy n, Enemy p, Enemy o, Enemy r)
    {
        ddosEnemyPrefab = d;
        trojanPrefab = t;
        networkPrefab = n;
        polymorphicPrefab = p;
        overwritePrefab = o;
        residentPrefab = r;
    }

    private void Start()
    {
        currentRound = 1;
        roundButton.GetComponent<ImageSelection>().Select();
        selectable = false;
    }

    void Update()
    {

        countdown -= Time.deltaTime;
        if (countdown <= 0 && !selectable)
        {
            roundButton.GetComponent<ImageSelection>().Select();
            selectable = true;
        }
    }

    public void callWave()
    {
        if (countdown <= 0 && selectable)
        {
            countdown = timeBetweenWaves;
            StartCoroutine(spawnWave());
            roundButton.GetComponent<ImageSelection>().Select();
            selectable = false;
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
        
        Enemy g = Object.Instantiate(prefab);
        g.towerShop = towerShop;

        return g;
    }

    public void ResetRounds()
    {
        currentRound = 1;
    }
}