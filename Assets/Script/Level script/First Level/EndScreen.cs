using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject purchasedScreen;
    public GameObject fade;
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        fade.SetActive(false);
        purchasedScreen.SetActive(false);
        buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyTicket()
    {
        purchasedScreen.SetActive(true);
        StartCoroutine(Wait());
        
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        fade.SetActive(true);
        buttons.SetActive(true);
    }
}
