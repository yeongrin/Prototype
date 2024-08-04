using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstableFolder : MonoBehaviour
{
    MiniGame2 _MG2;
    Animator ani;

    public void Start()
    {
        ani = GetComponent<Animator>();
        _MG2 = GameObject.FindObjectOfType<MiniGame2>().GetComponent<MiniGame2>();
    }

    void Update()
    {
        if(_MG2.isChange == true)
        {
            ChangeFileColor();
        }
    }

    void ChangeFileColor()
    {
        ani.SetBool("timer", true);
    }

    public void DestroyObj()
    {
        StartCoroutine("SoundOutput");

    }

    IEnumerator SoundOutput()
    {
        _MG2.timer2 = 3f;
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
