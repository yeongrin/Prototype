using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public enum BubbleState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform bubble;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private BubbleState state = BubbleState.COUNTING;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }
        waveCountdown = timeBetweenWaves;
    }


    void Update()
    {
        if (state == BubbleState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                //Begin a new round
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != BubbleState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }

        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = BubbleState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMEPLETED.");
        }
        else
        {
            nextWave++;
        }

        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                return false;
            }


        }
        return true;
    }

    IEnumerator SpawnWave(Wave _waves)
    {
        Debug.Log("Spawning Wave:" + _waves.name);
        state = BubbleState.SPAWNING;
        //Spawn

        for (int i = 0; i < _waves.count; i++)
        {
            SpawnEnemy(_waves.bubble);
            yield return new WaitForSeconds(1f / _waves.rate);
        }

        state = BubbleState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning enemy!:" + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
