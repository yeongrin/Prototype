using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rates;
    }

    // Start is called before the first frame update
    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    
    void Update()
    {
        if(state == SpawnState.WAITING) 
        { 
            if (!EnemyIsAlive ())
            {
                //Begin a new round
            }
            else
            {

            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }

        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0)
        { 
            if (GameObject.FindGameObjectsWithTag ("Enemy") == null)
        {
            return false;
        }

           
        }
       return true;
    }

    IEnumerator SpawnWave(Wave _waves)
    {
        state = SpawnState.SPAWNING;
        //Spawn

        for (int i = 0; i < _waves.count; i++)
        {
            SpawnEnemy(_waves.enemy);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Spawn.enemy
        Debug.Log("Spawning enemy!:" + _enemy.name);
    }
}
