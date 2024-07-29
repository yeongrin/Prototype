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
    public bool hasClicked;

    public GameObject bonusTextbox;
    public TMP_Text bonusText;
    public TextMeshProUGUI textDisplay;
    


    void Start()
    {
        spawnTimer = Random.Range(12f, 24f);
        hasSpawned = false;
        bonusTextbox.SetActive(false);
        hasClicked = false;
        
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

        if(hasClicked == true)
        {
            StartCoroutine(FadeOut());
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
        targetTimer = Random.Range(2f, 5f);
        target = newTarget[Random.Range(0, newTarget.Length)];
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

    public IEnumerator FadeOut()
    {
        bonusTextbox.SetActive(true);
        float duration = 2f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            textDisplay.color = new Color(textDisplay.color.r, textDisplay.color.g, textDisplay.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
