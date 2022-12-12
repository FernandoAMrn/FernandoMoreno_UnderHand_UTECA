using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public Transform parentToReturnTo = null;
    public bool isBlackTurn;

    private void Start()
    {
        isBlackTurn = true;
    }

    public void changeTurns()
    {
        isBlackTurn = !isBlackTurn;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        if (isBlackTurn == true)
        {
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
        //Debug.Log("OnDrag");
        if (isBlackTurn == true)
        {
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

        if (isBlackTurn == true)
        {
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

        if (other.CompareTag("WhiteCard"))
        {
            Debug.Log("Coliding with white card");
            this.transform.SetParent(parentToReturnTo);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }


}
