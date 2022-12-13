using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_W : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public Transform parentToReturnTo = null;
    public bool isWhiteTurn;
    public bool isMoving;

    private void start()
    {
        isMoving = true;
        isWhiteTurn = false;
    }

    public void changeTurn()
    {
        isWhiteTurn = !isWhiteTurn;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isWhiteTurn == true)
        {
            //Debug.Log("OnBeginDrag");
            isMoving = true;
            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else
        {
            return;
        }
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isWhiteTurn == true)
        {
            //Debug.Log("OnDrag");
            isMoving = true;
            this.transform.position = eventData.position;
        }
        else
        {
            return;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");

        if (isWhiteTurn == true)
        {
            isMoving = false;
            this.transform.SetParent(parentToReturnTo);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            return;
        }
        


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("BlackCard"))
        {
            Debug.Log("Coliding with black card");
            this.transform.SetParent(parentToReturnTo);
        }
    }
}
