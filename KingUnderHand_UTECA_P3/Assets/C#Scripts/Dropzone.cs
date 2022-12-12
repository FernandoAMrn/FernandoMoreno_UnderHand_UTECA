using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
   public void OnPointerEnter (PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }

    public void OnDrop (PointerEventData eventData)
    {
        Debug.Log( eventData.pointerDrag.name + "was dropped to" + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }

        Draggable_W e = eventData.pointerDrag.GetComponent<Draggable_W>();
        if (e != null)
        {
            e.parentToReturnTo = this.transform;
        }
    }

    
}
