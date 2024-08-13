using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondLevel : MonoBehaviour
{ 
    public Image Panel2;
    float time2 = 0f;
    float F_time2 = 1f;

    //public Image Panel3;
    float time3 = 0f;
    float F_time3 = 1f;

    float time4 = 0f;
    float F_time4 = 1f;

    public void Fade2()
    {
        StartCoroutine(FadeFlow2());
    }

    IEnumerator FadeFlow2()
    {
        StartCoroutine(Wait());
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

    public void Fade3()
    {
        StartCoroutine(FadeFlow3());
    }

    IEnumerator FadeFlow3()
    {
        Panel2.gameObject.SetActive(true);
        Color alpha = Panel2.color;
        while (alpha.a < 1f)
        {
            time3 += Time.deltaTime / F_time3;
            alpha.a = Mathf.Lerp(0, 1, time3);
            Panel2.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ThirdScene");
    }

    public void Fade4()
    {
        StartCoroutine(FadeFlow4());

    }

    IEnumerator FadeFlow4()
    {
        /*Panel2.gameObject.SetActive(true);
        Color alpha = Panel2.color;
        while (alpha.a < 1f)
        {
            time4 += Time.deltaTime / F_time4;
            alpha.a = Mathf.Lerp(0, 1, time4);
            Panel2.color = alpha;
            yield return null;
        }*/
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ForthScene");
        yield return null;
    }

    public void SetActivetrue()
    {
        
        this.gameObject.SetActive(true);

    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
