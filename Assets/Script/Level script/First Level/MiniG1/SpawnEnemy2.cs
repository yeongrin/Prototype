using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy2 : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

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
    public Transform spawnPoint;
    public float timeBetweenWaves;
    public float waveCountdown;
    public float time;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public Button button;
    
    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("35");
        }
        waveCountdown = timeBetweenWaves;
        time = 0f;
    }

    
    void Update()
    {
        time += Time.deltaTime;

        if (GameManager.over1 == false)
        {

            if (state == SpawnState.WAITING)
            {
                // Check if enemies are still alive
                if (!EnemyIsAlive())
                {
                    //Begin a new round
                    WaveCompleted();
                    //return; Looping first wave
                }
                else
                {
                    return;
                }
            }

            if (waveCountdown <= 0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                    //Start spawing waves;
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }

            //Time passed. Faster more Faster
            if (time >= 15)
            {
                timeBetweenWaves = 1;

                if (time >= 25)
                    timeBetweenWaves = 0;
            }
        }

        if(GameManager.over1 == true)
        {
            StopCoroutine(SpawnWave(waves[nextWave]));
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves complete! Looping..");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
       searchCountdown -= Time.deltaTime;
       if(searchCountdown <= 0f)
       {
            searchCountdown = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
              return false;
            }

       }
       

        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        //Debug.Log("Spawning Wave:" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    public void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("Spawning Enemy:" + _enemy.name);
        Transform _sp = spawnPoints[Random.Range (0, spawnPoints.Length)];
        Transform sPoint = _sp.gameObject.transform;
        spawnPoint = sPoint;
        //Stores the spawnpoint position for the button script to call when assigning car movement.
        Transform go = Instantiate(_enemy, _sp.transform.position, _sp.transform.rotation);
        button.car = go.gameObject;
    }
}
