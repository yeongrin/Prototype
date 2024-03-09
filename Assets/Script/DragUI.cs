using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{

    //private Image image;
    private RectTransform rect;


    private void Awake()
    {
        //image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        //image.color = Color.yellow;
    }

    // Update is called once per frame
    public void OnPointerExit(PointerEventData eventData)
    {
        //image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }

        
    }
}
