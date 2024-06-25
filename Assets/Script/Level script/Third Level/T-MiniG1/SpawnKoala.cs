using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKoala : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }
        timeBetweenWaves = Random.Range(0f, 5f);
        waveCountdown = timeBetweenWaves;
    }


    void Update()
    { 

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {

                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING && nextWave < waves.Length)
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
        timeBetweenWaves = Random.Range(0f, 5f);

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            //Debug.Log("ALL WAVES COMEPLETED!! Looping...");
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
            if (GameObject.FindGameObjectWithTag("elements") == null)

            {

                return false;

            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _waves)
    {
        //Debug.Log("Spawning Wave:" + _waves.name);
        state = SpawnState.SPAWNING;


        for (int i = 0; i < _waves.count; i++)
        {
            SpawnEnemy(_waves.enemy);
            yield return new WaitForSeconds(1f / _waves.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("Spawning enemy!:" + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.transform.position, _sp.transform.rotation);

    }
}
