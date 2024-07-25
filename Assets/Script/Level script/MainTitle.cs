using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainTitle : MonoBehaviour
{
    GameObject SplashObj;
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    float time2 = 0f;
    float F_time2 = 1f;

    //public Image Panel3;
    float time3 = 0f;
    float F_time3 = 1f;

    float time4 = 0f;
    float F_time4 = 1f;

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("FirstLevel");
    }

    public void Fade2()
    {
        StartCoroutine(FadeFlow2());
    }

    IEnumerator FadeFlow2()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time2 += Time.deltaTime / F_time2;
            alpha.a = Mathf.Lerp(0, 1, time2);
            Panel.color = alpha;
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
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time3 += Time.deltaTime / F_time3;
            alpha.a = Mathf.Lerp(0, 1, time3);
            Panel.color = alpha;
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
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time4 += Time.deltaTime / F_time4;
            alpha.a = Mathf.Lerp(0, 1, time4);
            Panel.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ForthScene");
    }

    public void Fade5()
    {
        StartCoroutine(FadeFlow5());

    }

    IEnumerator FadeFlow5()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time4 += Time.deltaTime / F_time4;
            alpha.a = Mathf.Lerp(0, 1, time4);
            Panel.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("FiveScene");
    }

    public void SetActivetrue()
    {
        this.gameObject.SetActive(true);
    }
}
