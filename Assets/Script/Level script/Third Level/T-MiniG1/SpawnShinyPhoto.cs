using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnShinyPhoto : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform spawnPoint;
    public GameObject shinyPhoto;
    public Transform target;
    public Transform[] newTarget;
    bool hasSpawned;
    
    public float spawnTimer;
    public float targetTimer;
    public float fadeTimer = 4f;
    public bool fadeTime = false;

    public GameObject bonusTextbox;
    public TMP_Text bonusText;
    


    void Start()
    {
        spawnTimer = Random.Range(1f, 3f);
        hasSpawned = false;
        bonusTextbox.SetActive(false);
        
    }

    
    void Update()
    {
        if(spawnTimer > 0)
            spawnTimer -= Time.deltaTime;

        if(fadeTime == true)
            fadeTimer -= Time.deltaTime;

        if(fadeTimer <= 0)
            bonusTextbox.SetActive(false);

        if(spawnTimer < 0 && hasSpawned == false)
        {
            SpawnShiny();
        }
    }

    void SpawnShiny()
    {
        spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(shinyPhoto, spawnPoint.transform.position, transform.rotation);
        target = spawnPoints[Random.Range(0, spawnPoints.Length)];
        hasSpawned = true;
        
        StartCoroutine(TargetTimerStart());
    }

    IEnumerator TargetTimerStart()
    {
        targetTimer -= Time.deltaTime;
        targetTimer = Random.Range(0f, 2f);
        target = newTarget[Random.Range(0,spawnPoints.Length)];
        yield return new WaitForSeconds(1f);

        StartCoroutine(TargetTimerStart());
        yield return null;
    }

    public IEnumerator BonusText()
    {
        print("Bouns");
        bonusText.text = "Bonus Photo Unlocked!!!";
        bonusTextbox.SetActive(true);
        fadeTime = true;

        yield return null;
    }
}
