using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler

{
    private Transform canvas;
    private Transform previousParants;
    private RectTransform rect;
    private CanvasGroup canvasGroup;

    public int slot = 0;


    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
           
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParants = transform.parent;

        transform.SetParent(canvas);
        transform.SetAsLastSibling();

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

   
    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent == canvas)
        {
            transform.SetParent(previousParants);
            rect.position = previousParants.GetComponent<RectTransform>().position;

        }

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "Equipment Slot Variant")
    //    {
    //        slot = 1;
    //    }
    //}
}
