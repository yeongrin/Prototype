using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Obstaclecoin : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    MiniGame4 _MG4;
    Animator ani;

    public void Start()
    {
        ani = GetComponent<Animator>();
        _MG4 = GameObject.FindObjectOfType<MiniGame4>().GetComponent<MiniGame4>();
    }

    void Update()
    {
        if (_MG4.isChange == true)
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
       
        Destroy(this.gameObject);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void PointerClick(PointerEventData eventData)
    {

    }

    public void test()
    {
        Debug.Log("clocking");
    }
}
