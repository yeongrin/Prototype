using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class SecondLevel : MonoBehaviour
{ 
    public Image Panel2;
    float time2 = 0f;
    float F_time2 = 1f;

    public void Fade2()
    {
        StartCoroutine(FadeFlow2());
    }

    IEnumerator FadeFlow2()
    {
        Panel2.gameObject.SetActive(true);
        Color alpha = Panel2.color;
        while (alpha.a < 1f)
        {
            time2 += Time.deltaTime / F_time2;
            alpha.a = Mathf.Lerp(0, 1, time2);
            Panel2.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("SecondScene");
    }
}
