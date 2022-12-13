using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    
    public Transform parentToReturnTo = null;
    public bool isBlackTurn;
    public bool isMoving;
    public ManaContainer mana;

    private void Start()
    {
        isMoving = false;
        isBlackTurn = true;
    }

    public void changeTurns()
    {
        isBlackTurn = !isBlackTurn;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        if (isBlackTurn == true && mana.mana >=1 )
        {
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

    public void OnDrag(PointerEventData eventData )
    {
        
        //Debug.Log("OnDrag");
        if (isBlackTurn == true && mana.mana >= 1)
        {
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

        if (isBlackTurn == true )
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

        if (other.CompareTag("WhiteCard"))
        {
            Debug.Log("Coliding with white card");
            this.transform.SetParent(parentToReturnTo);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }


}
